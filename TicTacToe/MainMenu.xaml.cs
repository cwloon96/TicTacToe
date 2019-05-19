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
            Difficult difficult = new Difficult();
            NavigationService.GetNavigationService(this).Navigate(difficult);
        }

        private void btnMultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            WhoFirst wf = new WhoFirst();
            NavigationService.GetNavigationService(this).Navigate(wf);
        }
    }
}
