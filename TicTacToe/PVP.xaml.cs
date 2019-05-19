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

        public bool getResult()
        {
            if (table[0] != 0 && table[0] == table[1] && table[0] == table[2])
            {
                return true;
            }
            else if (table[0] != 0 && table[0] == table[3] && table[0] == table[6])
            {
                return true;
            }
            else if (table[0] != 0 && table[0] == table[4] && table[0] == table[8])
            {
                return true;
            }
            else if (table[1] != 0 && table[1] == table[4] && table[1] == table[7])
            {
                return true;
            }
            else if (table[3] != 0 && table[3] == table[4] && table[3] == table[5])
            {
                return true;
            }
            else if (table[6] != 0 && table[6] == table[7] && table[6] == table[8])
            {
                return true;
            }
            else if (table[2] != 0 && table[2] == table[4] && table[2] == table[6])
            {
                return true;
            }
            else if (table[2] != 0 && table[2] == table[5] && table[2] == table[8])
            {
                return true;
            }
            return false;
        }

        private void Lbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            counter += 1;
            Label lbl = sender as Label;
            if (lbl.Name.Equals("lbl1"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl1.Content = FindResource(notChoice);
                    table[0] = 1;
                }
                else // Player1
                {
                    //put X
                    lbl1.Content = FindResource(choice);
                    table[0] = 2;
                }
                lbl1.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl2"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl2.Content = FindResource(notChoice);
                    table[1] = 1;
                }
                else //Player 1
                {
                    lbl2.Content = FindResource(choice);
                    table[1] = 2;
                }
                lbl2.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl3"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl3.Content = FindResource(notChoice);
                    table[2] = 1;
                }
                else //Player 1
                {
                    lbl3.Content = FindResource(choice);
                    table[2] = 2;
                }
                lbl3.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl4"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl4.Content = FindResource(notChoice);
                    table[3] = 1;
                }
                else //Player 1
                {
                    lbl4.Content = FindResource(choice);
                    table[3] = 2;
                }
                lbl4.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl5"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl5.Content = FindResource(notChoice);
                    table[4] = 1;
                }
                else //Player 1
                {
                    lbl5.Content = FindResource(choice);
                    table[4] = 2;
                }
                lbl5.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl6"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl6.Content = FindResource(notChoice);
                    table[5] = 1;
                }
                else //Player 1
                {
                    lbl6.Content = FindResource(choice);
                    table[5] = 2;
                }
                lbl6.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl7"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl7.Content = FindResource(notChoice);
                    table[6] = 1;
                }
                else //Player 1
                {
                    lbl7.Content = FindResource(choice);
                    table[6] = 2;
                }
                lbl7.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl8"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl8.Content = FindResource(notChoice);
                    table[7] = 1;
                }
                else //Player 1
                {
                    lbl8.Content = FindResource(choice);
                    table[7] = 2;
                }
                lbl8.IsEnabled = false;
            }
            else if (lbl.Name.Equals("lbl9"))
            {
                if (counter % 2 == 0) //Player 2
                {
                    lbl9.Content = FindResource(notChoice);
                    table[8] = 1;
                }
                else //Player 1
                {
                    lbl9.Content = FindResource(choice);
                    table[8] = 2;
                }
                lbl9.IsEnabled = false;
            }

            if (getResult())
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
