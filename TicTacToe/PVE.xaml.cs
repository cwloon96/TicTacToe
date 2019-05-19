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
        int counter = 0;
        MainMenu menu = new MainMenu();
        bool aiMove = false;
        bool aiFirst = false;
        Random rnd = new Random();
        int selection = 0;
        bool end = false;
        int aiNum = 0;
        int pplNum = 0;
        
        string playerKey = Application.Current.Properties["playerUse"].ToString();
        string aiKey = "";
        string diff = Application.Current.Properties["diff"].ToString();
        string whoFirst = Application.Current.Properties["whoFirst"].ToString();

        public PVE()
        {
            InitializeComponent();
            setDiff(diff);
            setAiKey();
            setMove();
            if (aiFirst)
                AiMove();
        }

        public void setDiff(string diff)
        {
            if (diff.Equals("easy"))
                selection = 1;
            else if (diff.Equals("medium"))
                selection = 2;
            else if (diff.Equals("hard"))
                selection = 3;
        }

        public void setAiKey()
        {
            aiKey = playerKey.Equals("X") ? "O" : "X";
        }

        public void setMove()
        {
            if (whoFirst.Equals("computer"))
            {          
                aiMove = true;
                aiFirst = true;
                aiNum = 1;
                pplNum = 2;
            }
            else
            {
                aiMove = false;
                aiFirst = false;
                pplNum = 1;
                aiNum = 2;
            }
        }
        
        public void AiMove()
        {
            counter += 1;
            if (selection >= 1)
            {
                completeRow();
                blockRow();
            }
            if (selection >= 2)
                setTrap();
            if (selection >= 3)
                blockTrap();
            randMove();

            if (!end)
            {
                if (getResult())
                {
                    MessageBox.Show("Computer Win!");
                    end = true;
                    reset();
                    NavigationService.GetNavigationService(this).Navigate(menu);
                }
                else if (counter == 9)
                {
                    MessageBox.Show("Draw!");
                    end = true;
                    reset();
                    NavigationService.GetNavigationService(this).Navigate(menu);
                }
            }
        }

        public void completeRow()
        {
            if (table[0] == 0 && table[1] == aiNum && table[2] == aiNum) //top row
            {
                table[0] = aiNum;
                lbl1.Content = FindResource(aiKey);
                lbl1.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[1] == 0 && table[2] == aiNum)//top row
            {
                table[1] = aiNum;
                lbl2.Content = FindResource(aiKey);
                lbl2.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[1] == aiNum && table[2] == 0)//top row
            {
                table[2] = aiNum;
                lbl3.Content = FindResource(aiKey);
                lbl3.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == 0 && table[3] == aiNum && table[4] == aiNum) //mid row --
            {
                table[5] = aiNum;
                lbl6.Content = FindResource(aiKey);
                lbl6.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == aiNum && table[3] == 0 && table[4] == aiNum)//mid row --
            {
                table[3] = aiNum;
                lbl4.Content = FindResource(aiKey);
                lbl4.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == aiNum && table[3] == aiNum && table[4] == 0)//mid row --
            {
                table[4] = aiNum;
                lbl5.Content = FindResource(aiKey);
                lbl5.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[6] == 0 && table[7] == aiNum && table[8] == aiNum) //btm row
            {
                table[6] = aiNum;
                lbl7.Content = FindResource(aiKey);
                lbl7.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[6] == aiNum && table[7] == 0 && table[8] == aiNum)//btm row
            {
                table[7] = aiNum;
                lbl8.Content = FindResource(aiKey);
                lbl8.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[6] == aiNum && table[7] == aiNum && table[8] == 0)//btm row
            {
                table[8] = aiNum;
                lbl9.Content = FindResource(aiKey);
                lbl9.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == 0 && table[3] == aiNum && table[6] == aiNum) //left row
            {
                table[0] = aiNum;
                lbl1.Content = FindResource(aiKey);
                lbl1.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[3] == 0 && table[6] == aiNum)//left row
            {
                table[3] = aiNum;
                lbl4.Content = FindResource(aiKey);
                lbl4.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[3] == aiNum && table[6] == 0)//left row
            {
                table[6] = aiNum;
                lbl7.Content = FindResource(aiKey);
                lbl7.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[4] == 0 && table[1] == aiNum && table[7] == aiNum) //mid row |
            {
                table[4] = aiNum;
                lbl5.Content = FindResource(aiKey);
                lbl5.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[4] == aiNum && table[1] == 0 && table[7] == aiNum)//mid row |
            {
                table[1] = aiNum;
                lbl2.Content = FindResource(aiKey);
                lbl2.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[4] == aiNum && table[1] == aiNum && table[7] == 0)//mid row |
            {
                table[7] = aiNum;
                lbl8.Content = FindResource(aiKey);
                lbl8.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == 0 && table[2] == aiNum && table[8] == aiNum) //right row
            {
                table[5] = aiNum;
                lbl6.Content = FindResource(aiKey);
                lbl6.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == aiNum && table[2] == 0 && table[8] == aiNum)//right row
            {
                table[2] = aiNum;
                lbl3.Content = FindResource(aiKey);
                lbl3.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[5] == aiNum && table[2] == aiNum && table[8] == 0)//right row
            {
                table[8] = aiNum;
                lbl9.Content = FindResource(aiKey);
                lbl9.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == 0 && table[4] == aiNum && table[8] == aiNum) //top left to btm right
            {
                table[0] = aiNum;
                lbl1.Content = FindResource(aiKey);
                lbl1.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[4] == 0 && table[8] == aiNum) //top left to btm right
            {
                table[4] = aiNum;
                lbl5.Content = FindResource(aiKey);
                lbl5.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[0] == aiNum && table[4] == aiNum && table[8] == 0) //top left to btm right
            {
                table[8] = aiNum;
                lbl9.Content = FindResource(aiKey);
                lbl9.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[2] == 0 && table[4] == aiNum && table[6] == aiNum) //top right to btm left
            {
                table[2] = aiNum;
                lbl3.Content = FindResource(aiKey);
                lbl3.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[2] == aiNum && table[4] == 0 && table[6] == aiNum)//top right to btm left
            {
                table[4] = aiNum;
                lbl5.Content = FindResource(aiKey);
                lbl5.IsEnabled = false;
                aiMove = false;
                getResult();
            }
            else if (table[2] == aiNum && table[4] == aiNum && table[6] == 0)//top right to btm left
            {
                table[6] = aiNum;
                lbl7.Content = FindResource(aiKey);
                lbl7.IsEnabled = false;
                aiMove = false;
                getResult();
            }
        }

        public void blockRow()
        {
            if (aiMove)
            {
                if (table[0] == 0 && table[1] == pplNum && table[2] == pplNum) //top row
                {
                    table[0] = aiNum;
                    lbl1.Content = FindResource(aiKey);
                    lbl1.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[1] == 0 && table[2] == pplNum)//top row
                {
                    table[1] = aiNum;
                    lbl2.Content = FindResource(aiKey);
                    lbl2.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[1] == pplNum && table[2] == 0)//top row
                {
                    table[2] = aiNum;
                    lbl3.Content = FindResource(aiKey);
                    lbl3.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == 0 && table[3] == pplNum && table[4] == pplNum) //mid row --
                {
                    table[5] = aiNum;
                    lbl6.Content = FindResource(aiKey);
                    lbl6.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == pplNum && table[3] == 0 && table[4] == pplNum)//mid row --
                {
                    table[3] = aiNum;
                    lbl4.Content = FindResource(aiKey);
                    lbl4.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == pplNum && table[3] == pplNum && table[4] == 0)//mid row --
                {
                    table[4] = aiNum;
                    lbl5.Content = FindResource(aiKey);
                    lbl5.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[6] == 0 && table[7] == pplNum && table[8] == pplNum) //btm row
                {
                    table[6] = aiNum;
                    lbl7.Content = FindResource(aiKey);
                    lbl7.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[6] == pplNum && table[7] == 0 && table[8] == pplNum)//btm row
                {
                    table[7] = aiNum;
                    lbl8.Content = FindResource(aiKey);
                    lbl8.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[6] == pplNum && table[7] == pplNum && table[8] == 0)//btm row
                {
                    table[8] = aiNum;
                    lbl9.Content = FindResource(aiKey);
                    lbl9.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == 0 && table[3] == pplNum && table[6] == pplNum) //left row
                {
                    table[0] = aiNum;
                    lbl1.Content = FindResource(aiKey);
                    lbl1.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[3] == 0 && table[6] == pplNum)//left row
                {
                    table[3] = aiNum;
                    lbl4.Content = FindResource(aiKey);
                    lbl4.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[3] == pplNum && table[6] == 0)//left row
                {
                    table[6] = aiNum;
                    lbl7.Content = FindResource(aiKey);
                    lbl7.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[4] == 0 && table[1] == pplNum && table[7] == pplNum) //mid row |
                {
                    table[4] = aiNum;
                    lbl5.Content = FindResource(aiKey);
                    lbl5.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[4] == pplNum && table[1] == 0 && table[7] == pplNum)//mid row |
                {
                    table[1] = aiNum;
                    lbl2.Content = FindResource(aiKey);
                    lbl2.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[4] == pplNum && table[1] == pplNum && table[7] == 0)//mid row |
                {
                    table[7] = aiNum;
                    lbl8.Content = FindResource(aiKey);
                    lbl8.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == 0 && table[2] == pplNum && table[8] == pplNum) //right row
                {
                    table[5] = aiNum;
                    lbl6.Content = FindResource(aiKey);
                    lbl6.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == pplNum && table[2] == 0 && table[8] == pplNum)//right row
                {
                    table[2] = aiNum;
                    lbl3.Content = FindResource(aiKey);
                    lbl3.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[5] == pplNum && table[2] == pplNum && table[8] == 0)//right row
                {
                    table[8] = aiNum;
                    lbl9.Content = FindResource(aiKey);
                    lbl9.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == 0 && table[4] == pplNum && table[8] == pplNum) //top left to btm right
                {
                    table[0] = aiNum;
                    lbl1.Content = FindResource(aiKey);
                    lbl1.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[4] == 0 && table[8] == pplNum) //top left to btm right
                {
                    table[4] = aiNum;
                    lbl5.Content = FindResource(aiKey);
                    lbl5.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[0] == pplNum && table[4] == pplNum && table[8] == 0) //top left to btm right
                {
                    table[8] = aiNum;
                    lbl9.Content = FindResource(aiKey);
                    lbl9.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[2] == 0 && table[4] == pplNum && table[6] == pplNum) //top right to btm left
                {
                    table[2] = aiNum;
                    lbl3.Content = FindResource(aiKey);
                    lbl3.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[2] == pplNum && table[4] == 0 && table[6] == pplNum)//top right to btm left
                {
                    table[4] = aiNum;
                    lbl5.Content = FindResource(aiKey);
                    lbl5.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
                else if (table[2] == pplNum && table[4] == pplNum && table[6] == 0)//top right to btm left
                {
                    table[6] = aiNum;
                    lbl7.Content = FindResource(aiKey);
                    lbl7.IsEnabled = false;
                    aiMove = false;
                    getResult();
                }
            }
        }
        
        public void setTrap()
        {
            if (aiMove)
            {
                if (table[4] == aiNum && table[0] == aiNum && table[2] == 0 && table[6] == 0)
                {
                    if (table[1] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[3] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[4] == aiNum && table[0] == 0 && table[2] == aiNum && table[8] == 0)
                {
                    if (table[1] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[5] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[4] == aiNum && table[6] == 0 && table[2] == 0 && table[8] == aiNum)
                {
                    if (table[7] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[5] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[4] == aiNum && table[0] == 0 && table[6] == aiNum && table[8] == 0)
                {
                    if (table[3] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[7] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[3] == aiNum && table[1] == aiNum)
                {
                    if (table[5] == 0 && table[7] == 0 && table[4] == 0)
                    {
                        table[4] = aiNum;
                        lbl5.Content = FindResource(aiKey);
                        lbl5.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[2] == 0 && table[6] == 0 && table[0] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[5] == aiNum && table[1] == aiNum)
                {
                    if (table[3] == 0 && table[7] == 0 && table[4] == 0)
                    {
                        table[4] = aiNum;
                        lbl5.Content = FindResource(aiKey);
                        lbl5.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[0] == 0 && table[8] == 0 && table[2] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[5] == aiNum && table[7] == aiNum)
                {
                    if (table[1] == 0 && table[3] == 0 && table[4] == 0)
                    {
                        table[4] = aiNum;
                        lbl5.Content = FindResource(aiKey);
                        lbl5.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[2] == 0 && table[6] == 0 && table[8] == 0)
                    {
                        table[8] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[3] == aiNum && table[7] == aiNum)
                {
                    if (table[5] == 0 && table[1] == 0 && table[4] == 0)
                    {
                        table[4] = aiNum;
                        lbl5.Content = FindResource(aiKey);
                        lbl5.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[0] == 0 && table[8] == 0 && table[6] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                }
            }
        }

        public void blockTrap()
        {
            if (aiMove)
            {
                if (table[4] == pplNum)
                {
                    if (table[0] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[2] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[6] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[8] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[1] == pplNum || table[3] == pplNum || table[5] == pplNum || table[7] == pplNum)
                {
                    if (table[1] == pplNum && table[3] == 0)
                    {
                        table[3] = aiNum;
                        lbl4.Content = FindResource(aiKey);
                        lbl4.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[1] == pplNum && table[5] == 0)
                    {
                        table[5] = aiNum;
                        lbl6.Content = FindResource(aiKey);
                        lbl6.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[5] == pplNum && table[1] == 0)
                    {
                        table[1] = aiNum;
                        lbl2.Content = FindResource(aiKey);
                        lbl2.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[5] == pplNum && table[7] == 0)
                    {
                        table[7] = aiNum;
                        lbl8.Content = FindResource(aiKey);
                        lbl8.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[7] == pplNum && table[3] == 0)
                    {
                        table[3] = aiNum;
                        lbl4.Content = FindResource(aiKey);
                        lbl4.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[7] == pplNum && table[5] == 0)
                    {
                        table[5] = aiNum;
                        lbl6.Content = FindResource(aiKey);
                        lbl6.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[3] == pplNum && table[1] == 0)
                    {
                        table[1] = aiNum;
                        lbl2.Content = FindResource(aiKey);
                        lbl2.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[3] == pplNum && table[7] == 0)
                    {
                        table[7] = aiNum;
                        lbl8.Content = FindResource(aiKey);
                        lbl8.IsEnabled = false;
                        aiMove = false;
                    }
                }
                else if (table[0] == pplNum || table[2] == pplNum || table[6] == pplNum || table[8] == pplNum)
                {
                    if (table[0] == pplNum && table[2] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[0] == pplNum && table[6] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[2] == pplNum && table[0] == 0)
                    {
                        table[1] = aiNum;
                        lbl2.Content = FindResource(aiKey);
                        lbl2.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[2] == pplNum && table[8] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[8] == pplNum && table[2] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[8] == pplNum && table[6] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[6] == pplNum && table[0] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                        aiMove = false;
                    }
                    else if (table[6] == pplNum && table[8] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                        aiMove = false;
                    }
                }
            }
        }

        public void randMove()
        {
            while (aiMove)
            {
                int n = rnd.Next(9);
                if (table[n] == 0)
                {
                    n += 1;
                    string lbl = String.Concat("lbl", String.Format("" + n));
                    if (lbl.Equals("lbl1") && table[0] == 0)
                    {
                        table[0] = aiNum;
                        lbl1.Content = FindResource(aiKey);
                        lbl1.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl2") && table[1] == 0)
                    {
                        table[1] = aiNum;
                        lbl2.Content = FindResource(aiKey);
                        lbl2.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl3") && table[2] == 0)
                    {
                        table[2] = aiNum;
                        lbl3.Content = FindResource(aiKey);
                        lbl3.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl4") && table[3] == 0)
                    {
                        table[3] = aiNum;
                        lbl4.Content = FindResource(aiKey);
                        lbl4.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl5") && table[4] == 0)
                    {
                        table[4] = aiNum;
                        lbl5.Content = FindResource(aiKey);
                        lbl5.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl6") && table[5] == 0)
                    {
                        table[5] = aiNum;
                        lbl6.Content = FindResource(aiKey);
                        lbl6.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl7") && table[6] == 0)
                    {
                        table[6] = aiNum;
                        lbl7.Content = FindResource(aiKey);
                        lbl7.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl8") && table[7] == 0)
                    {
                        table[7] = aiNum;
                        lbl8.Content = FindResource(aiKey);
                        lbl8.IsEnabled = false;
                    }
                    else if (lbl.Equals("lbl9") && table[8] == 0)
                    {
                        table[8] = aiNum;
                        lbl9.Content = FindResource(aiKey);
                        lbl9.IsEnabled = false;
                    }
                    aiMove = false;
                }
            }
        }

        public bool getResult()
        {
            if (!end)
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
            }
            return false;
        }

        private void lbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            counter += 1;
            Label lbl = sender as Label;
            lbl.Content = FindResource(playerKey);
            int num = int.Parse(lbl.Name[3].ToString()) - 1;
            table[num] = pplNum;
            lbl.IsEnabled = false;
            //if (lbl.Name.Equals("lbl1"))
            //{
            //    lbl1.Content = FindResource(playerKey);
            //    table[0] = pplNum;
            //    lbl1.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl2"))
            //{
            //    lbl2.Content = FindResource(playerKey);
            //    table[1] = pplNum;
            //    lbl2.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl3"))
            //{
            //    lbl3.Content = FindResource(playerKey);
            //    table[2] = pplNum;
            //    lbl3.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl4"))
            //{
            //    lbl4.Content = FindResource(playerKey);
            //    table[3] = pplNum;
            //    lbl4.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl5"))
            //{
            //    lbl5.Content = FindResource(playerKey);
            //    table[4] = pplNum;
            //    lbl5.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl6"))
            //{
            //    lbl6.Content = FindResource(playerKey);
            //    table[5] = pplNum;
            //    lbl6.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl7"))
            //{
            //    lbl7.Content = FindResource(playerKey);
            //    table[6] = pplNum;
            //    lbl7.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl8"))
            //{
            //    lbl8.Content = FindResource(playerKey);
            //    table[7] = pplNum;
            //    lbl8.IsEnabled = false;
            //}
            //else if (lbl.Name.Equals("lbl9"))
            //{
            //    lbl9.Content = FindResource(playerKey);
            //    table[8] = pplNum;
            //    lbl9.IsEnabled = false;
            //}
            if (!end)
            {
                aiMove = true;
                if (getResult())
                {
                    MessageBox.Show("Player Win!");
                    end = true;
                    aiMove = false;
                    reset();
                    NavigationService.GetNavigationService(this).Navigate(menu);
                }
                else if (counter == 9)
                {
                    MessageBox.Show("Draw!");
                    end = true;
                    aiMove = false;
                    reset();
                    NavigationService.GetNavigationService(this).Navigate(menu);
                }
                else if (aiMove)
                    AiMove();
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
