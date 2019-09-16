using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnSinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Difficult());
        }

        private void btnMultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new WhoFirst());
        }
    }
}