namespace UI_Vaja_2
{
    internal class BoardState
    {
        private int[,] board;
        public int[,] staticBoard { get; set; }
        private int ocena;

        public BoardState()
        {
            this.board = new int[3, 3];
        }

        public BoardState(int[,] a)
        {
            this.board = (int[,])a.Clone();
            int ocenaMax = BoardHeuristics(a, 2);
            int ocenaMin = BoardHeuristics(a, 1);
            this.ocena = ocenaMax - ocenaMin;
        }

        public int IS_OVER(int[,] a)
        {
            int numZero = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int l = 0; l < 3; l++)
                {
                    if (a[i, l] == 0)
                    {
                        numZero++;
                    }
                }
            }
            if (numZero == 0)
            {
                return -1;
            }

            int j = 0;
            for (int i = 0; i < 3; i++)
            {
                if (a[i, j] != 0)
                {
                    if (i == 0)
                    {
                        if (a[i, 0] == 1 && a[i + 1, 1] == 1 && a[i + 2, 2] == 1)
                        {
                            return 1;
                        }
                    }
                    if (a[i, 0] == 1 && a[i, 1] == 1 && a[i, 2] == 1)
                    {
                        return 1;
                    }
                    if (i == 2)
                    {
                        if (a[i, 0] == 1 && a[i - 1, 1] == 1 && a[i - 2, 2] == 1)
                        {
                            return 1;
                        }
                    }

                    if (i == 0)
                    {
                        if (a[i, 0] == 2 && a[i + 1, 1] == 2 && a[i + 2, 2] == 2)
                        {
                            return 2;
                        }
                    }
                    if (a[i, 0] == 2 && a[i, 1] == 2 && a[i, 2] == 2)
                    {
                        return 2;
                    }
                    if (i == 2)
                    {
                        if (a[i, 0] == 2 && a[i - 1, 1] == 2 && a[i - 2, 2] == 2)
                        {
                            return 2;
                        }
                    }
                }
            }
            j = 0;
            for (int k = 0; k < 3; k++)
            {
                if (a[0, k] == 1 && a[1, k] == 1 && a[2, k] == 1)
                {
                    return 1;
                }
                if (a[0, k] == 2 && a[1, k] == 2 && a[2, k] == 2)
                {
                    return 2;
                }
            }

            return 0;
        }

        public int BoardHeuristics(int[,]a, int player)
        {
            int taken_line = 0;

            if (a[0, 0] == player || a[0, 1] == player || a[0, 2] == player)
            {
                taken_line++;
            }
            if (a[1, 0] == player || a[1, 1] == player || a[1, 2] == player)
            {
                taken_line++;
            }
            if (a[2, 0] == player || a[2, 1] == player || a[2, 2] == player)
            {
                taken_line++;
            }
            if (a[0, 0] == player || a[1, 0] == player || a[2, 0] == player)
            {
                taken_line++;
            }
            if (a[0, 1] == player || a[1, 1] == player || a[2, 1] == player)
            {
                taken_line++;
            }
            if (a[0, 2] == player || a[1, 2] == player || a[2, 2] == player)
            {
                taken_line++;
            }
            if (a[0, 2] == player || a[1, 1] == player || a[2, 0] == player)
            {
                taken_line++;
            }
            if (a[2, 0] == player || a[1, 1] == player || a[0, 2] == player)
            {
                taken_line++;
            }

            return (8 - taken_line);
        }

        public void setBoard(int[,] a)
        {
            this.board = (int[,])a.Clone();

            int state = IS_OVER(a);
            if (state == 1)
            {
                this.ocena = 100000;
            }
            else if (state == 2)
            {
                this.ocena = (-100000);
            }
            else
            {
                int ocenaMax = BoardHeuristics(a, 2);
                int ocenaMin = BoardHeuristics(a, 1);
                this.ocena = ocenaMax - ocenaMin;
            }
        }

        public void setOnlyBoard(int [,]a)
        {
            this.board = (int[,])a.Clone();
        }

        public void setBoard()
        { 
            this.board = new int[3, 3];
        }

        public int[, ]getBoard()
        {
            return this.board;
        }

        public void setBoardAtPosition(int x, int y, int value)
        {
            board[x, y] = value;
            int state = IS_OVER(board);
            if (state == 1)
            {
                this.ocena = 100000;
            }
            else if (state == 2)
            {
                this.ocena = (-100000);
            }
            else
            {
                int ocenaMax = BoardHeuristics(board, 2);
                int ocenaMin = BoardHeuristics(board, 1);
                this.ocena = ocenaMax - ocenaMin;
            }
        }

        public int getBoardAtPosition(int x, int y)
        {
            return board[x, y];
        }

        public void setOcena(int ocena)
        {
            this.ocena = ocena;
        }

        
        public int getStaticOcena()
        {
            return ocena;
        }

        public int getOcena()
        {
            int state = IS_OVER(board);
            if (state == 1)
            {
                return 100000;
            }
            else if (state == 2)
            {
                return (-100000);
            }
            else
            {
                int ocenaMax = BoardHeuristics(board, 2);
                int ocenaMin = BoardHeuristics(board, 1);
                return ocenaMax - ocenaMin;
            }

        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

    }
}