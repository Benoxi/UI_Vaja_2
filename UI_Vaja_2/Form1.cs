using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Vaja_2
{
    public partial class Form1 : Form
    {
        private BoardState GameBoard = new BoardState();

        private int current_player = 1;

        public Form1()
        {
            InitializeComponent();
        }
        /*
        private int CHECK_STEP(int[,] a, int[,] b)
        {
            int step = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        step++;
                    }
                }
            }

            return step;
        }

        private void WRITE_TO_CONSOLE()
        {
            Console.WriteLine("WRITE TO CONSOLE OUTPUT: \n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard.getBoardAtPosition(i, j) > -1)
                    {
                        Console.Write(" " + GameBoard.getBoardAtPosition(i, j));
                    }
                    else
                    {
                        Console.Write("" + GameBoard.getBoardAtPosition(i, j));
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }

        private void DEBUG_BOARD(int[,] a)
        {
            Console.WriteLine("DEBUG_BOARD OUTPUT:  \n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[i, j] > -1)
                    {
                        Console.Write(" " + a[i, j]);
                    }
                    else
                    {
                        Console.Write("" + a[i, j]);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }
        */
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
                    if (GameBoard.getBoardAtPosition(i, j) == 1)
                    {
                        drawPoint = new PointF((0 + (j * 216)), (0 + (i * 216)));
                        g1.DrawString(drawX, drawFont, drawBrush, drawPoint);
                    }
                    else if (GameBoard.getBoardAtPosition(i, j) == 2)
                    {
                        drawPoint = new PointF((0 + (j * 216)), (0 + (i * 216)));
                        g1.DrawString(drawO, drawFont, drawBrush, drawPoint);
                    }
                }
            }
        }

        private int STATE(int[,] a)
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

        private List<BoardState> MOVES(BoardState P, int player)
        {
            List<BoardState> boardStates = new List<BoardState>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (P.getBoardAtPosition(i, j) == 0)
                    {
                        BoardState newState = new BoardState();
                        newState.setBoard(P.getBoard());
                        newState.setBoardAtPosition(i, j, player);
                        boardStates.Add(newState);
                    }
                }
            }
            
            return boardStates;
        }

        private BoardState ALPHA_BETA(BoardState P, int player, int d, int alpha, int beta)
        {
            if (STATE(P.getBoard()) == -1 || d == 0)
            {
                P.getOcena();
                P.Reset();
                return P;
            }
            BoardState A = new BoardState();
            if (player == 1)
            {
                A.setOcena(-100000);
            }
            else if (player == 2)
            {
                A.setOcena(100000);
            }

            List<BoardState> M = new List<BoardState>();

            A.Reset();

            M = MOVES(P, player);

            BoardState R = new BoardState();
            BoardState G = new BoardState();

            foreach (var m in M)
            {
                R.setBoard(m.getBoard());

                if (player == 1)
                {
                    G = ALPHA_BETA(R, 2, (d - 1),alpha,beta);
                }
                else if (player == 2)
                {
                    G = ALPHA_BETA(R, 1, (d - 1),alpha,beta);
                }
                else
                {
                    Console.WriteLine("\n\n\n\n FATAL ERROR ?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?! \n\n\n\n");
                }
                if(player == 1 && G.getOcena() > A.getStaticOcena())  //ALPHA
                {
                    A.setOnlyBoard(m.getBoard());
                    A.setOcena(G.getOcena());
                    if(A.getStaticOcena() > alpha)
                    {
                        alpha = A.getStaticOcena();
                    }
                }
                else if (player == 2 && G.getOcena() < A.getStaticOcena())  //BETA
                {
                    A.setOnlyBoard(m.getBoard());
                    A.setOcena(G.getOcena());
                    if (A.getStaticOcena() < beta)
                    {
                        beta = A.getStaticOcena();
                    }
                }
                if (alpha >= beta)
                {
                    return A;
                }
            }
            return A;
        }

        private BoardState OMEJENI_MINIMAKS(BoardState P, int player, int d)
        {
            if (STATE(P.getBoard()) == -1 || d == 0)
            {
                P.getOcena();
                P.Reset();
                return P;
            }
            BoardState A = new BoardState();
            if (player == 1)
            {
                A.setOcena(-100000);
            }
            else if (player == 2)
            {
                A.setOcena(100000);
            }

            List<BoardState> M = new List<BoardState>();

            A.Reset();

            M = MOVES(P, player);

            BoardState R = new BoardState();
            BoardState G = new BoardState();

            foreach (var m in M)
            {
                R.setBoard(m.getBoard());

                if (player == 1)
                {
                    G = OMEJENI_MINIMAKS(R, player + 1, (d - 1));
                }
                else if (player == 2)
                {
                    G = OMEJENI_MINIMAKS(R, player - 1, (d - 1));
                }
                else
                {
                    Console.WriteLine("\n\n\n\n FATAL ERROR ?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?!?! \n\n\n\n");
                }
                if ((player == 1 && G.getOcena() > A.getStaticOcena()) || (player == 2 && G.getOcena() < A.getStaticOcena()))
                {
                    A.setOnlyBoard(m.getBoard());
                    A.setOcena(G.getOcena());
                }
            }
            return A;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameBoard.Reset();

            GameBox.Enabled = false;
            //PlayAI.Enabled = false;

            DISPLAY();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            int level = Int32.Parse(LevelBox.Text.ToString());

            GameBox.Enabled = true;
        }

        private void CLEAR()
        {
            GameBoard.Reset();
            DISPLAY();
        }

        private void GameBox_Click(object sender, EventArgs e)
        {
            GameBox.Enabled = false;


            int level = Int32.Parse(LevelBox.Text.ToString());

            MouseEventArgs MC = (MouseEventArgs)e;
            Point coordinates = MC.Location;

            int x, y;
            x = coordinates.X - 8;
            y = coordinates.Y - 8;

            //Xcoord.Text = x.ToString();
            //Ycoord.Text = y.ToString();
            x = (int)(x / 210);
            y = (int)(y / 210);

            int correct_move = 0;

            if (x > 2)
            {
                x = 2;
            }
            if (y > 2)
            {
                y = 2;
            }

            if (GameBoard.getBoardAtPosition(y, x) == 0)
            {
                GameBoard.setBoardAtPosition(y, x, 1);
                //WarningLbl.Text = "Set board at x: " + y + " y: " + x + " !";
                correct_move = 1;
            }
            else
            {
                WarningLbl.Text = "Field x: " + y + " y: " + x + " already taken!!!";
                correct_move = 0;
            }

            DISPLAY();

            int a = STATE(GameBoard.getBoard());

            if (a != 0)
            {
                if (a == 1)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Zmagal je igralec X";
                    return;
                }
                if (a == 2)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Zmagal je igralec O";
                    return;
                }
                if (a == -1)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Ni zmagovalca !";
                    return;
                }
            }
            if (correct_move == 1)
            {
                if(AlgorithmBox.Text.ToString().Equals("MINIMAX BY DEPTH"))
                {
                    GameBoard = OMEJENI_MINIMAKS(GameBoard, 2, level);
                }
                else if (AlgorithmBox.Text.ToString().Equals("ALPHA-BETA"))
                {
                    int alpha = -100000;
                    int beta = 100000;
                    GameBoard = ALPHA_BETA(GameBoard, 2, level, alpha, beta);
                }
            }

            DISPLAY();

            GameBox.Enabled = true;

            a = STATE(GameBoard.getBoard());

            if (a != 0)
            {
                if (a == 1)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Zmagal je igralec X";
                    return;
                }
                if (a == 2)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Zmagal je igralec O";
                    return;
                }
                if (a == -1)
                {
                    GameBox.Enabled = false;
                    WarningLbl.Text = "Ni zmagovalca !";
                    return;
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            CLEAR();
            GameBox.Enabled = false;
        }

        /*
        private void PlayAI_Click(object sender, EventArgs e)
        {
            int level = Int32.Parse(LevelBox.Text.ToString());

            Console.WriteLine("Level je: " + level);

            while (true)
            {
                DISPLAY();

                GameBoard = OMEJENI_MINIMAKS(GameBoard, current_player, level);

                DISPLAY();

                if (current_player == 1)
                {
                    current_player = 2;
                }
                else
                {
                    current_player = 1;
                }

                DISPLAY();

                int a = STATE(GameBoard.getBoard());

                if (a != 0)
                {
                    if (a == 1)
                    {
                        WarningLbl.Text = "Zmagal je igralec X";
                        WRITE_TO_CONSOLE();
                        return;
                    }
                    if (a == 2)
                    {
                        WarningLbl.Text = "Zmagal je igralec O";
                        WRITE_TO_CONSOLE();
                        return;
                    }
                    if (a == -1)
                    {
                        WarningLbl.Text = "Ni zmagovalca !";
                        WRITE_TO_CONSOLE();
                        return;
                    }
                }
            }
        }
        */

    }
}