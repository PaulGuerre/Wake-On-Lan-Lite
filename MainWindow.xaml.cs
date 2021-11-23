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

            /*dataGrid.ItemsSource = this.devices;
            this.devices.Add(new Device() { NAME = "Server number 3", ADDRESS = "aa:bb:cc:dd:ee:ff" });
            this.devices.Add(new Device() { NAME = "PC1", ADDRESS = "ff:ee:dd:cc:bb:aa" });
            this.devices.Add(new Device() { NAME = "Server2", ADDRESS = "zz:yy:xx:ww:vv:uu" });*/
        }

        //Refresh dataGrid data
        public void dataRefresh()
        {
            /*dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = this.devices;*/
        }

        //Add data to dataGrid and file
        public void addData(string name, string address)
        {
            /*if(address == null)
            {
                //fileControl.add...
                this.devices.Add(new Device() { NAME = name, ADDRESS = "" });
            }
            else
            {
                //fileControl.update...
                this.devices[dataGrid.Items.Count - 2].ADDRESS = address;
            }
            dataRefresh();*/
        }

        public void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*if(dataGrid.CurrentColumn != null)
            {
                TextBox t = e.EditingElement as TextBox;

                if (dataGrid.CurrentColumn.DisplayIndex == dataGrid.Columns.Count - 2)
                {
                    addData(t.Text.ToString(), null);
                    dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 2], dataGrid.Columns[dataGrid.Columns.Count - 1]);
                }
                else
                {
                    addData(null, t.Text.ToString());
                    dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 1], dataGrid.Columns[dataGrid.Columns.Count - 2]);
                }

                dataGrid.BeginEdit();
            }*/
        }

        //When click "add" button
        public void showAdd(object sender, RoutedEventArgs e)
        {
            /*dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count - 1], dataGrid.Columns[dataGrid.Columns.Count - 2]);
            dataGrid.BeginEdit();*/
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
    }
}
