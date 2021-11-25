using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wake_On_Lan_Lite
{
    public partial class MainWindow : Window
    {
        private fileControl file = new fileControl();

        public MainWindow()
        {
            InitializeComponent();

            file.createFileIfNotExist();

            dataRefresh();
        }

        public void dataRefresh()
        {
            this.deviceList.ItemsSource = null;
            this.deviceList.ItemsSource = file.getAllAddresses();
        }

        //Show the edit device window to add or update a device
        public void showEditDevice(object sender, RoutedEventArgs e)
        {
            editDevice edit = new editDevice(this);
            edit.editDeviceTitle.Text = sender.ToString().Contains("Button") ? "Add device" : "Update device";
            edit.editDeviceButton.Content = sender.ToString().Contains("Button") ? "Add" : "Update";
            edit.Show();
        }

        //Delete a device
        public void deleteDevice(object sender, RoutedEventArgs e)
        {
            Device device = (Device)this.deviceList.SelectedItem;
            this.file.deleteAddress(device, this);

            dataRefresh();
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
