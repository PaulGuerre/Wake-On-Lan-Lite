using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

namespace Wake_On_Lan_Lite
{

    public class Device
    {
        public string NAME { set; get; }
        public string ADDRESS { set; get; }
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            fileControl file = new fileControl();

            file.createFileIfNotExist();

            List<Device> device = new List<Device>();

            device.Add(new Device() { NAME = "Sever0", ADDRESS = "aa:bb:cc:dd:ee:ff" });
            device.Add(new Device() { NAME = "PC1", ADDRESS = "ff:ee:dd:cc:bb:aa" });
            device.Add(new Device() { NAME = "Server2", ADDRESS = "zz:yy:xx:ww:vv:uu" });

            dataGrid.ItemsSource = device;

            //Création du fichier MAC.txt pour stocker les adresses MAC
            /*if (Directory.Exists(PATH))
            {
                if (!File.Exists(PATHFILE))
                {
                    StreamWriter newFile = new StreamWriter(PATHFILE);
                    newFile.Close();
                }
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(PATH);
                StreamWriter newFile = new StreamWriter(PATHFILE);
                newFile.Close();
            }*/

            //Récupération des adresses MAC stockées dans le fichier .txt et affichage de ces données dans la listBox
            /*int cpt = 0;
            string line;

            StreamReader file = new StreamReader(PATHFILE);
            while ((line = file.ReadLine()) != null)
            {
                LB1.Items.Add(line);
                cpt++;
            }*/
        }

        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        /*void WOL_Click(object sender, RoutedEventArgs e)
        {
            //Réinitialisation de la progressBar, puis appel de la méthode WakeUp (Wake On Lan)
            ProgressBar1.Value = 0;
            ProgressBar1.IsIndeterminate = false;

            if (LB1.SelectedItem != null)
            {
                WakeUp(LB1.SelectedItem.ToString());
            }
        }

        void add_Click(object sender, RoutedEventArgs e)
        {
            //Vérification du texte entré dans la textBox (adresse MAC) et ajout de ce dernier dans la listBox ainsi que dans le fichier .txt
            Regex r = new Regex("^([0-9A-Fa-f]{2}[:]){5}([0-9A-Fa-f]{2})$");

            if (r.IsMatch(TB1.Text))
            {
                LB1.Items.Add(TB1.Text);

                using (StreamWriter file =
                    new StreamWriter(PATHFILE, true))
                {
                    file.WriteLine(TB1.Text);
                }
            }
        }

        void del_Click(object sender, RoutedEventArgs e)
        {
            //Suppression des adresses MAC contenues dans la listBox ainsi que dans le fichier .txt
            if (LB1.Items.Count == 1)
            {
                LB1.Items.Clear();
                string[] lines = { };
                File.WriteAllLines(PATHFILE, lines);
            }
            else
            {
                int pos = LB1.SelectedIndex;

                var file = new List<string>(File.ReadAllLines(PATHFILE));
                if (pos != 0)
                {
                    file.RemoveAt(pos);
                    File.WriteAllLines(PATHFILE, file.ToArray());
                }

                LB1.Items.Remove(LB1.SelectedItem);
            }
        }*/
    }
}
