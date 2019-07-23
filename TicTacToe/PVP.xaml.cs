using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class PVP : Page
    {
        int[] table = new int[9];
        int counter = 0;
        MainMenu menu = new MainMenu();
        string choice = "";
        string notChoice = "";

        public PVP()
        {
            InitializeComponent();
        }

        public void getChoice(string c)
        {
            if (c.Equals("circle"))
            {
                choice = "O";
                notChoice = "X";
            }
            else
            {
                choice = "X";
                notChoice = "O";
            }
        }

        public bool getResult(int lastMove)
        {
            return GameManager.Instance.CheckWinCondition(lastMove, table);
        }

        private void PlayerMove(object sender, MouseButtonEventArgs e)
        {
            counter += 1;
            Label lbl = sender as Label;
            int tableIndex = int.Parse(lbl.Name[3].ToString()) - 1;

            if (counter % 2 == 0) //Player 2
            {
                lbl.Content = FindResource(notChoice);
                table[tableIndex] = 1;
            }
            else
            {
                lbl.Content = FindResource(choice);
                table[tableIndex] = 2;
            }
            lbl.IsEnabled = false;

            if (getResult(tableIndex))
            {
                if (counter % 2 == 0)
                    MessageBox.Show("Player 2 Win!");
                else
                    MessageBox.Show("Player 1 Win!");
                reset();
                NavigationService.GetNavigationService(this).Navigate(menu);
            }

            if (counter == 9)
            {
                MessageBox.Show("Draw!");
                reset();
                NavigationService.GetNavigationService(this).Navigate(menu);
            }
        }

        public void reset()
        {
            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";
            lbl4.Content = "";
            lbl5.Content = "";
            lbl6.Content = "";
            lbl7.Content = "";
            lbl8.Content = "";
            lbl9.Content = "";
            counter = 0;
        }
    }
}
