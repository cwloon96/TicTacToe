using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class PVEWhoFirst : Page
    {
        public PVEWhoFirst()
        {
            InitializeComponent();
        }

        private void btnStartPlayer_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Application.Current.Properties["whoFirst"] = button.Name;
            PVE pve = new PVE();
            NavigationService.GetNavigationService(this).Navigate(pve);
        }
    }
}
