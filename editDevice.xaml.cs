using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Wake_On_Lan_Lite
{
    /// <summary>
    /// Logique d'interaction pour editDevice.xaml
    /// </summary>
    public partial class editDevice : Window
    {
        private MainWindow main;

        public editDevice(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        //Function that add or update device
        private void editDeviceClick(object sender, RoutedEventArgs e)
        {
            fileControl file = new fileControl();
            Regex r = new Regex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
            appMessageBox appMessage = new appMessageBox();

            nameTextBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
            addressTextBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            if (nameTextBox.Text == "")
            {
                nameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (!r.IsMatch(addressTextBox.Text))
            {
                addressTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (editDeviceButton.Content.ToString() == "Add")
                {
                    file.addAddress(new Device() { ID = file.getAllAddresses().Count, NAME = nameTextBox.Text, ADDRESS = addressTextBox.Text });
                }
                else
                {
                    Device updateDevice = (Device)main.deviceList.SelectedItem;
                    file.updateAddress(new Device() { ID = updateDevice.ID, NAME = nameTextBox.Text, ADDRESS = addressTextBox.Text });
                }
                this.main.dataRefresh();

                this.Close();
            }
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
