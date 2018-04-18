using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Vaja_2
{
    public partial class Form1 : Form
    {
        private BoardState GameBoard = new BoardState();

        public Form1()
        {
            InitializeComponent();
        }

        private void DISPLAY()
        {
            Graphics g1;

            GameBox.Image = new Bitmap(650, 650);

            g1 = Graphics.FromImage(this.GameBox.Image);

            Pen gridPen = new Pen(Color.Black, 10);

            for (int i = 1; i < 3; i++)
            {
                g1.DrawLine(gridPen, 215 * i, 0, 215 * i, 650);
                g1.DrawLine(gridPen, 0, 215 * i, 650, 215 * i);
            }
            int fontSize = 146;

            string drawX = "X";
            string drawO = "O";

            Font drawFont = new Font("Helvetica", fontSize);

            SolidBrush drawBrush = new SolidBrush(Color.Black);

            PointF drawPoint;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard.getBoardAtPosition(i,j) == 1)
                    {
                        drawPoint = new PointF((0 + (i * 216)), (0 + (j * 216)));
                        g1.DrawString(drawX, drawFont, drawBrush, drawPoint);
                    }
                    else if (GameBoard.getBoardAtPosition(i, j) == 2)
                    {
                        drawPoint = new PointF((0 + (i * 216)), (0 + (j * 216)));
                        g1.DrawString(drawO, drawFont, drawBrush, drawPoint);
                    }
                }
            }
        }

        private int STATE(int[,] a)
        {
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

        private List<BoardState> MOVES(BoardState P, int player)
        {
            List<BoardState> boardStates = new List<BoardState>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (P.getBoardAtPosition(i,j) == 0)
                    {
                        BoardState newState = new BoardState();
                        newState.setBoard(P.getBoard());
                        newState.setBoardAtPosition(i,j,player);
                        boardStates.Add(newState);
                    }
                }
            }

            /*
            Console.WriteLine("\nFIRST BOARD (INITIAL): ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (P.board[i, j] > -1)
                    {
                        Console.Write(" " + P.board[i, j]);
                    }
                    else
                    {
                        Console.Write("" + P.board[i, j]);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");

            foreach(var BS in boardStates)
            {
                for(int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (BS.board[i, j] > -1)
                        {
                            Console.Write(" " + BS.board[i, j]);
                        }
                        else
                        {
                            Console.Write("" + BS.board[i, j]);
                        }
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
            */

            return boardStates;
        }

        private BoardState OMEJENI_MINIMAKS(BoardState P, int player, int d)
        {
            if (STATE(P.getBoard()) != 0 || d == 0)
            {
                return P;
            }
            if (player == 1)
            {
                P.setOcena(-100000);
            }
            else if (player == 2)
            {
                P.setOcena(100000);
            }

            P.setBoard();

            List<BoardState> M = new List<BoardState>();
            M = MOVES(P, player);

            BoardState R = new BoardState();

            foreach (var m in M)
            {
                P.setBoard(m.getBoard());

                if (player == 1)
                {
                    R = OMEJENI_MINIMAKS(R, player + 1, (d - 1));
                }
                else if (player == 2)
                {
                    R = OMEJENI_MINIMAKS(R, player - 1, (d - 1));
                }
                else
                {
                    Console.WriteLine("\n\n\n\n FATAL ERROR ?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?! \n\n\n\n");
                }

                if ((player == 1 && R.getOcena() > P.getOcena()) || (player == 2 && R.getOcena() < P.getOcena()))
                {
                    P.setBoard(R.getBoard());
                }
            }
            return P;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameBoard.Reset();
            DISPLAY();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            int level = Int32.Parse(LevelBox.Text.ToString());

            Console.WriteLine("Level je: " + level);
        }

        private void CLEAR()
        {
            GameBoard.Reset();
            DISPLAY();
        }

        private void GameBox_Click(object sender, EventArgs e)
        {
            int level = Int32.Parse(LevelBox.Text.ToString());

            MouseEventArgs MC = (MouseEventArgs)e;
            Point coordinates = MC.Location;

            int x, y;
            x = coordinates.X - 8;
            y = coordinates.Y - 8;

            Xcoord.Text = x.ToString();
            Ycoord.Text = y.ToString();
            x = (x / 210);
            y = (y / 210);
            
            DISPLAY();

            if (GameBoard.getBoardAtPosition(x,y) == 0)
            {
                GameBoard.setBoardAtPosition(x, y, 1);
            }
            else
            {
                WarningLbl.Text = "Field x: " + x + " y: " + y + " already taken!!!";
            }
            
            GameBoard = OMEJENI_MINIMAKS(GameBoard, 2, level);
            
            DISPLAY();

            int a = STATE(GameBoard.getBoard()); 

            if (a != 0)
            {
                if (a == 1)
                {
                    WarningLbl.Text = "Zmagal je igralec X";
                    CLEAR();
                }
                if (a == 2)
                {
                    WarningLbl.Text = "Zmagal je igralec O";
                    CLEAR();
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            CLEAR();
        }
    }
}