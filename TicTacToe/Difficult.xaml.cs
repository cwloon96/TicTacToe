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
            PVESelection pVESelection = new PVESelection();
            Application.Current.Properties["diff"] = button.Name;
            NavigationService.GetNavigationService(this).Navigate(pVESelection);
        }
    }
}
