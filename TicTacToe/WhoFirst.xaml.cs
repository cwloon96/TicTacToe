using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class WhoFirst : Page
    {
        public WhoFirst()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            PVP pvp = new PVP();
            pvp.getChoice(button.Name);
            NavigationService.GetNavigationService(this).Navigate(pvp);
        }
    }
}
