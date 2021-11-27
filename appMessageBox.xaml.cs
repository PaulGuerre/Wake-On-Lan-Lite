using System.Windows;
using System.Windows.Input;
namespace Wake_On_Lan_Lite
{
    /// <summary>
    /// Logique d'interaction pour appMessageBox.xaml
    /// </summary>
    public partial class appMessageBox : Window
    {
        public appMessageBox()
        {
            InitializeComponent();
        }

        public void showMsg(string msg)
        {
            message.Content = msg;
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
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
