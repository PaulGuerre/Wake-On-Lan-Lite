using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Wake_On_Lan_Lite
{
    public partial class MainWindow : Window
    {
        private List<Device> devices = new List<Device>();

        public MainWindow()
        {
            InitializeComponent();

            fileControl file = new fileControl();
            file.createFileIfNotExist();

            dataGrid.ItemsSource = this.devices;
            this.devices.Add(new Device() { NAME = "Server number 3", ADDRESS = "aa:bb:cc:dd:ee:ff" });
            this.devices.Add(new Device() { NAME = "PC1", ADDRESS = "ff:ee:dd:cc:bb:aa" });
            this.devices.Add(new Device() { NAME = "Server2", ADDRESS = "zz:yy:xx:ww:vv:uu" });
        }

        public void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(dataGrid.CurrentColumn != null)
            {
                if (dataGrid.CurrentColumn.DisplayIndex == dataGrid.Columns.Count - 2)
                {
                    TextBox t = e.EditingElement as TextBox;
                    this.devices.Add(new Device() { NAME = t.Text.ToString(), ADDRESS = "" });
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = this.devices;
                    dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 2], dataGrid.Columns[dataGrid.Columns.Count - 1]);
                    dataGrid.BeginEdit();
                }
                else
                {
                    TextBox t = e.EditingElement as TextBox;
                    this.devices[dataGrid.Items.Count - 2].ADDRESS = t.Text.ToString();
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = this.devices;
                    dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 1], dataGrid.Columns[dataGrid.Columns.Count - 2]);
                    dataGrid.BeginEdit();
                }
            }
        }

        public void showAdd(object sender, RoutedEventArgs e)
        {
            dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 1], dataGrid.Columns[dataGrid.Columns.Count - 2]);
            dataGrid.BeginEdit();
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
