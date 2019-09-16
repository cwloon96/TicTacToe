using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class PVESelection : Page
    {
        public PVESelection()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Application.Current.Properties["playerUse"] = button.Name;
            NavigationService.GetNavigationService(this).Navigate(new PVEWhoFirst());
        }
    }
}