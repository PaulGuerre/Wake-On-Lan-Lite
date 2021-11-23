using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

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

            List<Device> devices = file.getAllAddresses();

            deviceList.ItemsSource = devices;
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
