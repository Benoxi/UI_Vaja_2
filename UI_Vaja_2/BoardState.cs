namespace UI_Vaja_2
{
    internal class BoardState
    {
        private int[,] board;
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
            int ocenaMax = BoardHeuristics(a, 2);
            int ocenaMin = BoardHeuristics(a, 1);
            this.ocena = ocenaMax - ocenaMin;
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
            int ocenaMax = BoardHeuristics(this.board, 2);
            int ocenaMin = BoardHeuristics(this.board, 1);
            this.ocena = (ocenaMax - ocenaMin);
        }

        public int getBoardAtPosition(int x, int y)
        {
            return board[x, y];
        }

        public void setOcena(int ocena)
        {
            this.ocena = ocena;
        }

        /*
        public int getOcena()
        {
            return ocena;
        }*/

        public int getOcena()
        {
            int ocenaMax = BoardHeuristics(this.board, 2);
            int ocenaMin = BoardHeuristics(this.board, 1);
            return (ocenaMax - ocenaMin);
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