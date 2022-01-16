using System.Windows;
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

        //Function that refresh listBox data
        public void dataRefresh()
        {
            this.deviceList.ItemsSource = null;
            this.deviceList.ItemsSource = file.getAllAddresses();
        }

        //Show the edit device window to add or update a device
        public void showEditDevice(object sender, RoutedEventArgs e)
        {
            editDevice edit = new editDevice(this);
            Device device = (Device)this.deviceList.SelectedItem;

            if (sender.ToString().Contains("Button") || device.NAME == "+")
            {
                edit.editDeviceTitle.Text = "Add device";
                edit.editDeviceButton.Content = "Add";
            }
            else
            {
                edit.editDeviceTitle.Text = "Update device";
                edit.editDeviceButton.Content = "Update";
                edit.nameTextBox.Text = device.NAME;
                edit.addressTextBox.Text = device.ADDRESS;
            }

            edit.Show();
        }

        //Delete a device
        public void deleteDevice(object sender, RoutedEventArgs e)
        {
            Device device = (Device)this.deviceList.SelectedItem;

            if (device != null && device.NAME != "+")
            {
                this.file.deleteAddress(device, this);
                dataRefresh();
            }
            else
            {
                appMessageBox appMessage = new appMessageBox();
                appMessage.Show();

                appMessage.showMsg("Please select a device");
            }
        }

        //Send the magic packet
        private void WakeUp(object sender, RoutedEventArgs e)
        {
            Device device = (Device)this.deviceList.SelectedItem;

            if (device != null && device.NAME != "+")
            {
                networkControl nc = new networkControl();
                notificationService ns = new notificationService();
                
                nc.wakeUp(device.ADDRESS);
                ns.sendNotification(device.NAME);
            }
            else
            {
                appMessageBox appMessage = new appMessageBox();
                appMessage.Show();

                appMessage.showMsg("Please select a device");
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
