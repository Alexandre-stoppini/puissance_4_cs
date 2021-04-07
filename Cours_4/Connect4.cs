using System;
using System.Collections.Generic;
using System.Text;

namespace Cours_4
{
    class Connect4
    {
        int[,] table = new int[13, 14];
        int player = 0;
        private int[] playerPos = new int[2] {0, 0};


        public int LineCount
        {
            get { return 12; }
        }

        public int ColCount => 13;

        public char GetPawn(int col, int line)
        {
            char result = ' ';

            if (table[col, line] == 1)
            {
                return result = 'O';
            }
            else if (table[col, line] == 2)
            {
                return result = 'X';
            }
            else
            {
                return result = ' ';
            }
        }

        public int PlayerNumber()
        {
            if (player == 1)
            {
                player++;
            }
            else if (player == 2)
            {
                player--;
            }
            else
            {
                player++;
            }

            return player;
        }

        public void Play(int column)
        {
            column += 2;
            int i = LineCount - 4;

            for (;;)
            {
                if (i == 2)
                {
                    throw new ArgumentException("Choose an other column. This one is full.");
                    Console.WriteLine("Choose an other column. This one is full.");
                    player--;
                    break;
                }
                else if (table[column, i] == 0)
                {
                    table[column, i] = player;

                    playerPos[0] = column;
                    playerPos[1] = i;
                    break;
                }
                else if (table[column, i] == 1 || table[column, i] == 2)
                {
                    i--;
                }
            }
        }

        public int Winner()
        {
            int x = playerPos[0], y = playerPos[1];
            for (int i = -3; i < 0; i++)
            {
                if (table[x + i, y] == player && 
                    table[x + i + 1, y] == player && 
                    table[x + i + 2, y] == player &&
                    table[x + i + 3, y] == player)
                {
                    return player;
                }
                else if (table[x, y] == player && 
                         table[x, y - 1] == player && 
                         table[x, y - 2] == player &&
                         table[x, y - 3] == player)
                {
                    return player;
                }
                else if (table[x + i, y - i] == player && 
                         table[x + i + 1, y - i - 1] == player &&
                         table[x + i + 2, y - i - 2] == player &&
                         table[x + i + 3, y - i - 3] == player)
                {
                    return player;
                }
                else if (table[x - i, y - i] == player && 
                         table[x - i - 1, y - i - 1] == player &&
                         table[x - i - 2, y - i - 2] == player &&
                         table[x - i - 3, y - i - 3] == player)
                {
                    return player;
                }
            }
            

            if (table[3, 3] != 0 && table[4, 3] != 0 && table[5, 3] != 0 && table[6, 3] != 0 && table[7, 3] != 0 &&
                table[8, 3] != 0 && table[9, 3] != 0)
            {
                return 3;
            }

            return 0;
        }


        public bool Ended()
        {
            bool cond = Winner() != 0;
            return cond;
        }
    }
}