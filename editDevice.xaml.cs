using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wake_On_Lan_Lite
{
    /// <summary>
    /// Logique d'interaction pour editDevice.xaml
    /// </summary>
    public partial class editDevice : Window
    {
        public editDevice()
        {
            InitializeComponent();
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

        private void editDeviceClick(object sender, RoutedEventArgs e)
        {
            fileControl file = new fileControl();
            file.addAddress(new Device() { NAME = nameTextBox.Text, ADDRESS = addressTextBox.Text });

            this.Close();
        }
    }
}
