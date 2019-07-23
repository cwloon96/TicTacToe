using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class Difficult : Page
    {
        public Difficult()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            PVESelection PVESelection = new PVESelection();
            Application.Current.Properties["difficulty"] = button.Name;
            NavigationService.GetNavigationService(this).Navigate(PVESelection);
        }
    }
}
