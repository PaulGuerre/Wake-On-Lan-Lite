using System.Windows;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Wake_On_Lan_Lite
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Création du fichier MAC.txt pour stocker les adresses MAC
            string path = @"C:\WOL";
            string pathFile = @"C:\WOL\MAC.txt";

            if (Directory.Exists(path))
            {
                if (!File.Exists(pathFile))
                {
                    StreamWriter newFile = new StreamWriter(@"C:\WOL\MAC.txt");
                    newFile.Close();
                }
            }
            else
            {
                StreamWriter newFile = new StreamWriter(@"C:\WOL\MAC.txt");
                newFile.Close();
            }

            //Récupération des adresses MAC stockées dans le fichier .txt et affichage de ces données dans la listBox
            int cpt = 0;
            string line;

            StreamReader file = new StreamReader(@"C:\WOL\MAC.txt");
            while ((line = file.ReadLine()) != null)
            {
                LB1.Items.Add(line);
                cpt++;
            }
            file.Close();
        }

        //Fonction qui appel la fonction WakeUp
        private void WOL_Click(object sender, RoutedEventArgs e)
        {
            //Réinitialisation de la progressBar, puis appel de la méthode WakeUp (Wake On Lan)
            ProgressBar1.Value = 0;
            ProgressBar1.IsIndeterminate = false;

            if(LB1.SelectedItem != null)
            {
                WakeUp(LB1.SelectedItem.ToString());
            }
        }

        //Fonction qui envoie le paquet pour réveiller la machine
        private void WakeUp(string MAC_ADDRESS)
        {
            //Envoie du "magic packet" vers l'adresse MAC séléctionnée dans la listBox
            MAC_ADDRESS = Regex.Replace(MAC_ADDRESS, "[-|:]", "");

            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                EnableBroadcast = true
            };

            int payloadIndex = 0;

            byte[] payload = new byte[1024];

            for (int i = 0; i < 6; i++)
            {
                payload[payloadIndex] = 255;
                payloadIndex++;
            }

            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < MAC_ADDRESS.Length; k += 2)
                {
                    var s = MAC_ADDRESS.Substring(k, 2);
                    payload[payloadIndex] = byte.Parse(s, NumberStyles.HexNumber);
                    payloadIndex++;
                }
            }

            var ip = ConfigurationManager.AppSettings["255.255.255.255"];
            var address = IPAddress.Parse(ip);

            sock.SendTo(payload, new IPEndPoint(address, 0));
            sock.Close(10000);
            ProgressBar1.Value = 100;
        }

        //Fonction qui ajoute une adresse ip
        private void add_Click(object sender, RoutedEventArgs e)
        {
            //Vérification du texte entré dans la textBox (adresse MAC) et ajout de ce dernier dans la listBox ainsi que dans le fichier .txt
            Regex r = new Regex("^([0-9A-Fa-f]{2}[:]){5}([0-9A-Fa-f]{2})$");

            if (r.IsMatch(TB1.Text))
            {
                LB1.Items.Add(TB1.Text);

                using (StreamWriter file =
                    new StreamWriter(@"C:\WOL\MAC.txt", true))
                {
                    file.WriteLine(TB1.Text);
                }
            }
        }

        //Fonction qui supprime une adresse ip
        private void del_Click(object sender, RoutedEventArgs e)
        {
            //Suppression des adresses MAC contenues dans la listBox ainsi que dans le fichier .txt
            if (LB1.Items.Count == 1)
            {
                LB1.Items.Clear();
                string[] lines = { };
                File.WriteAllLines(@"C:\WOL\MAC.txt", lines);
            }
            else
            {
                int pos = LB1.SelectedIndex;

                var file = new List<string>(File.ReadAllLines(@"C:\WOL\MAC.txt"));
                if(pos != 0)
                {
                    file.RemoveAt(pos);
                    File.WriteAllLines(@"C:\WOL\MAC.txt", file.ToArray());
                }

                LB1.Items.Remove(LB1.SelectedItem);
            }
        }
    }
}
