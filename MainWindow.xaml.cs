using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

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

        private void showEditDevice(object sender, RoutedEventArgs e)
        {
            editDevice edit = new editDevice(this);
            edit.editDeviceTitle.Text = "Add device";
            edit.editDeviceButton.Content = "Add";
            edit.Show();
        }
    }
}
