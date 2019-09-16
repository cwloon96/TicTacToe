using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace TicTacToe
{
    public partial class PVE : Page
    {
        int[] table = new int[9];
        int currentTurn = 0;
        int level = 0;
        int aiNum = 0;
        int pplNum = 0;
        bool isAiFirst = false;
        bool end = false;
        Random random = new Random();

        string aiKey = "";
        string playerKey = Application.Current.Properties["playerUse"].ToString();
        string diff = Application.Current.Properties["difficulty"].ToString();
        string whoFirst = Application.Current.Properties["whoFirst"].ToString();

        public PVE()
        {
            InitializeComponent();
            SetDifficulty(diff);
            SetAiKey();
            SetMove();
            if (isAiFirst)
                AiMove();
        }

        public void SetDifficulty(string diff)
        {
            if (diff.Equals("easy"))
                level = 1;
            else if (diff.Equals("medium"))
                level = 2;
            else if (diff.Equals("hard"))
                level = 3;
        }

        public void SetAiKey()
        {
            aiKey = playerKey.Equals("X") ? "O" : "X";
        }

        public void SetMove()
        {
            if (whoFirst.Equals("computer"))
            {          
                isAiFirst = true;
                aiNum = 1;
                pplNum = 2;
            }
            else
            {
                pplNum = 1;
                aiNum = 2;
            }
        }
        
        public void AiMove()
        {
            currentTurn += 1;
            int lastMove = -1;
            if (level >= 1)
            {
                CompleteRow(ref lastMove);
                BlockRow(ref lastMove);
            }
            if (level >= 2)
                SetTrap(ref lastMove);
            if (level >= 3)
                BlockTrap(ref lastMove);
            randMove(ref lastMove);

            PlotAiMoveOnTable(lastMove);

            if (!end)
            {
                if (getResult(lastMove))
                    MessageBox.Show("Computer Win!");
                else if (currentTurn == 9)
                    MessageBox.Show("Draw!");
            }

            if (end)
            {
                reset();
                NavigationService.GetNavigationService(this).Navigate(new MainMenu());
            }
        }

        public void CompleteRow(ref int lastMove)
        {
            if ((table[0] == 0 && table[1] == aiNum && table[2] == aiNum) ||
                (table[0] == 0 && table[3] == aiNum && table[6] == aiNum) ||
                (table[0] == 0 && table[4] == aiNum && table[8] == aiNum))
            {
                lastMove = 0;
            }
            else if ((table[1] == 0 && table[0] == aiNum && table[2] == aiNum) ||
                     (table[1] == 0 && table[4] == aiNum && table[7] == aiNum))
            {
                lastMove = 1;
            }
            else if ((table[2] == 0 && table[0] == aiNum && table[1] == aiNum) ||
                     (table[2] == 0 && table[4] == aiNum && table[6] == aiNum) ||
                     (table[2] == 0 && table[5] == aiNum && table[8] == aiNum))
            {
                lastMove = 2;
            }
            else if ((table[3] == 0 && table[5] == aiNum && table[4] == aiNum) ||
                     (table[3] == 0 && table[0] == aiNum && table[6] == aiNum))
            {
                lastMove = 3;
            }
            else if ((table[4] == 0 &&table[5] == aiNum && table[3] == aiNum) ||
                     (table[4] == 0 && table[1] == aiNum && table[7] == aiNum) ||
                     (table[4] == 0 && table[0] == aiNum && table[8] == aiNum) ||
                     (table[4] == 0 && table[2] == aiNum && table[6] == aiNum))
            {
                lastMove = 4;
            }
            else if ((table[5] == 0 && table[3] == aiNum && table[4] == aiNum) ||
                     (table[5] == 0 && table[2] == aiNum && table[8] == aiNum))
            {
                lastMove = 5;
            }
            else if ((table[6] == 0 && table[7] == aiNum && table[8] == aiNum) ||
                     (table[6] == 0 && table[2] == aiNum && table[4] == aiNum) ||
                     (table[6] == 0 && table[0] == aiNum && table[3] == aiNum))
            {
                lastMove = 6;
            }
            else if ((table[7] == 0 && table[6] == aiNum && table[8] == aiNum) ||
                     (table[7] == 0 && table[4] == aiNum && table[1] == aiNum))
            {
                lastMove = 7;
            }
            else if ((table[8] == 0 && table[6] == aiNum && table[7] == aiNum) ||
                     (table[8] == 0 && table[5] == aiNum && table[2] == aiNum) ||
                     (table[8] == 0 && table[0] == aiNum && table[4] == aiNum))
            {
                lastMove = 8;
            }
        }

        public void BlockRow(ref int lastMove)
        {
            if (lastMove == -1)
            {
                if ((table[0] == 0 && table[1] == pplNum && table[2] == pplNum) ||
                    (table[0] == 0 && table[3] == pplNum && table[6] == pplNum) ||
                    (table[0] == 0 && table[4] == pplNum && table[8] == pplNum))
                {
                    lastMove = 0;
                }
                else if ((table[1] == 0 && table[0] == pplNum && table[2] == pplNum) ||
                         (table[1] == 0 && table[4] == pplNum && table[7] == pplNum))
                {
                    lastMove = 1;
                }
                else if ((table[2] == 0 && table[0] == pplNum && table[1] == pplNum) ||
                         (table[2] == 0 && table[4] == pplNum && table[6] == pplNum) ||
                         (table[2] == 0 && table[5] == pplNum && table[8] == pplNum))
                {
                    lastMove = 2;
                }
                else if ((table[3] == 0 && table[5] == pplNum && table[4] == pplNum) ||
                         (table[3] == 0 && table[0] == pplNum && table[6] == pplNum))
                {
                    lastMove = 3;
                }
                else if ((table[4] == 0 && table[5] == pplNum && table[3] == pplNum) ||
                         (table[4] == 0 && table[1] == pplNum && table[7] == pplNum) ||
                         (table[4] == 0 && table[0] == pplNum && table[8] == pplNum) ||
                         (table[4] == 0 && table[2] == pplNum && table[6] == pplNum))
                {
                    lastMove = 4;
                }
                else if ((table[5] == 0 && table[3] == pplNum && table[4] == pplNum) ||
                         (table[5] == 0 && table[2] == pplNum && table[8] == pplNum))
                {
                    lastMove = 5;
                }
                else if ((table[6] == 0 && table[7] == pplNum && table[8] == pplNum) ||
                         (table[6] == 0 && table[2] == pplNum && table[4] == pplNum) ||
                         (table[6] == 0 && table[0] == pplNum && table[3] == pplNum)) 
                {
                    lastMove = 6;
                }
                else if ((table[7] == 0 && table[6] == pplNum && table[8] == pplNum) ||
                         (table[7] == 0 && table[4] == pplNum && table[1] == pplNum))
                {
                    lastMove = 7;
                }
                else if ((table[8] == 0 && table[6] == pplNum && table[7] == pplNum) ||
                         (table[8] == 0 && table[5] == pplNum && table[2] == pplNum) ||
                         (table[8] == 0 && table[0] == pplNum && table[4] == pplNum))
                {
                    lastMove = 8;
                }
            }
        }
        
        public void SetTrap(ref int lastMove)
        {
            if (lastMove == -1)
            {
                if (table[4] == aiNum && table[0] == aiNum && table[2] == 0 && table[6] == 0)
                {
                    if (table[1] == 0)
                    {
                        lastMove = 2;
                    }
                    else if (table[3] == 0)
                    {
                        lastMove = 6;
                    }
                }
                else if (table[4] == aiNum && table[0] == 0 && table[2] == aiNum && table[8] == 0)
                {
                    if (table[1] == 0)
                    {
                        lastMove = 0;
                    }
                    else if (table[5] == 0)
                    {
                        lastMove = 8;
                    }
                }
                else if (table[4] == aiNum && table[6] == 0 && table[2] == 0 && table[8] == aiNum)
                {
                    if (table[7] == 0)
                    {
                        lastMove = 6;
                    }
                    else if (table[5] == 0)
                    {
                        lastMove = 2;
                    }
                }
                else if (table[4] == aiNum && table[0] == 0 && table[6] == aiNum && table[8] == 0)
                {
                    if (table[3] == 0)
                    {
                        lastMove = 0;
                    }
                    else if (table[7] == 0)
                    {
                        lastMove = 8;
                    }
                }
                else if (table[3] == aiNum && table[1] == aiNum)
                {
                    if (table[5] == 0 && table[7] == 0 && table[4] == 0)
                    {
                        lastMove = 4;
                    }
                    else if (table[2] == 0 && table[6] == 0 && table[0] == 0)
                    {
                        lastMove = 0;
                    }
                }
                else if (table[5] == aiNum && table[1] == aiNum)
                {
                    if (table[3] == 0 && table[7] == 0 && table[4] == 0)
                    {
                        lastMove = 4;
                    }
                    else if (table[0] == 0 && table[8] == 0 && table[2] == 0)
                    {
                        lastMove = 2;
                    }
                }
                else if (table[5] == aiNum && table[7] == aiNum)
                {
                    if (table[1] == 0 && table[3] == 0 && table[4] == 0)
                    {
                        lastMove = 4;
                    }
                    else if (table[2] == 0 && table[6] == 0 && table[8] == 0)
                    {
                        lastMove = 8;
                    }
                }
                else if (table[3] == aiNum && table[7] == aiNum)
                {
                    if (table[5] == 0 && table[1] == 0 && table[4] == 0)
                    {
                        lastMove = 4;
                    }
                    else if (table[0] == 0 && table[8] == 0 && table[6] == 0)
                    {
                        lastMove = 6;
                    }
                }
            }
        }

        public void BlockTrap(ref int lastMove)
        {
            if (lastMove == -1)
            {
                if (table[4] == pplNum)
                {
                    if (table[0] == 0)
                    {
                        lastMove = 0;
                    }
                    else if (table[2] == 0)
                    {
                        lastMove = 2;
                    }
                    else if (table[6] == 0)
                    {
                        lastMove = 6;
                    }
                    else if (table[8] == 0)
                    {
                        lastMove = 8;
                    }
                }
                else if (table[1] == pplNum || table[3] == pplNum || table[5] == pplNum || table[7] == pplNum)
                {
                    if (table[1] == pplNum && table[3] == 0)
                    {
                        lastMove = 3;
                    }
                    else if (table[1] == pplNum && table[5] == 0)
                    {
                        lastMove = 5;
                    }
                    else if (table[5] == pplNum && table[1] == 0)
                    {
                        lastMove = 1;
                    }
                    else if (table[5] == pplNum && table[7] == 0)
                    {
                        lastMove = 7;
                    }
                    else if (table[7] == pplNum && table[3] == 0)
                    {
                        lastMove = 3;
                    }
                    else if (table[7] == pplNum && table[5] == 0)
                    {
                        lastMove = 5;
                    }
                    else if (table[3] == pplNum && table[1] == 0)
                    {
                        lastMove = 1;
                    }
                    else if (table[3] == pplNum && table[7] == 0)
                    {
                        lastMove = 7;
                    }
                }
                else if (table[0] == pplNum || table[2] == pplNum || table[6] == pplNum || table[8] == pplNum)
                {
                    if (table[0] == pplNum && table[2] == 0)
                    {
                        lastMove = 2;
                    }
                    else if (table[0] == pplNum && table[6] == 0)
                    {
                        lastMove = 6;
                    }
                    else if (table[2] == pplNum && table[0] == 0)
                    {
                        lastMove = 1;
                    }
                    else if (table[2] == pplNum && table[8] == 0)
                    {
                        lastMove = 8;
                    }
                    else if (table[8] == pplNum && table[2] == 0)
                    {
                        lastMove = 2;
                    }
                    else if (table[8] == pplNum && table[6] == 0)
                    {
                        lastMove = 6;
                    }
                    else if (table[6] == pplNum && table[0] == 0)
                    {
                        lastMove = 0;
                    }
                    else if (table[6] == pplNum && table[8] == 0)
                    {
                        lastMove = 8;
                    }
                }
            }
        }

        public void randMove(ref int lastMove)
        {
            while (lastMove == -1 || table[lastMove] != 0)
            {
                lastMove = random.Next(9);
            }
        }

        public void PlotAiMoveOnTable(int tableIndex)
        {
            table[tableIndex] = aiNum;
            int labelNum = tableIndex + 1;
            string labelName = string.Concat("lbl", string.Format("" + labelNum));
            var label = FindName(labelName) as Label;
            label.Content = FindResource(aiKey);
            label.IsEnabled = false;
        }

        public bool getResult(int lastMove)
        {
            if (!end && GameManager.Instance.CheckWinCondition(lastMove, table))
                end = true;

            return end;
        }

        private void PlayerMove(object sender, MouseButtonEventArgs e)
        {
            currentTurn += 1;
            Label lbl = sender as Label;
            lbl.Content = FindResource(playerKey);
            int num = int.Parse(lbl.Name[3].ToString()) - 1;
            table[num] = pplNum;
            lbl.IsEnabled = false;
           
            if (!end)
            {
                if (getResult(num))
                    MessageBox.Show("Player Win!");
                else if (currentTurn == 9)
                    MessageBox.Show("Draw!");
                else
                    AiMove();
            }

            if (end)
            {
                reset();
                NavigationService.GetNavigationService(this).Navigate(new MainMenu());
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
            currentTurn = 0;
        }
    }
}