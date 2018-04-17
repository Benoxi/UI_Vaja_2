﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Vaja_2
{


    public partial class Form1 : Form
    {

        int[,] Board = new int[3, 3];

        public Form1()
        {
            InitializeComponent();
        }

        void DISPLAY(int[,] a)
        {
            Graphics g1;

            GameBox.Image = new Bitmap(650, 650);

            g1 = Graphics.FromImage(this.GameBox.Image);

            Pen gridPen = new Pen(Color.Black, 10);

            for (int i = 1; i < 3; i++)
            {
                g1.DrawLine(gridPen, 215*i, 0, 215*i, 650);
                g1.DrawLine(gridPen, 0, 215*i, 650, 215*i);
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
                    if(a[i,j] == 1)
                    {
                        drawPoint = new PointF((0 + (i * 216)), (0 + (j * 216)));
                        g1.DrawString(drawX, drawFont, drawBrush, drawPoint);
                    }
                    else if (a[i, j] == 2)
                    {
                        drawPoint = new PointF((0 + (i * 216)), (0 + (j * 216)));
                        g1.DrawString(drawO, drawFont, drawBrush, drawPoint);
                    }
                }

            }


        }

        int STATE(int[,]a)
        {

            int j = 0;

            for(int i = 0; i < 3; i++)
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
                    if(i == 2)
                    {
                        if (a[i, 2] == 1 && a[i - 1, 1] == 1 && a[i - 2, 0] == 1)
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
                        if (a[i, 2] == 2 && a[i - 1, 1] == 2 && a[i - 2, 0] == 2)
                        {
                            return 2;
                        }
                    }

                }
            }
            j = 0;
            for(int k = 0; k < 3; k++)
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

        private void Form1_Load(object sender, EventArgs e)
        {

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    /*
                    if(((i+j)%2) == 0)
                    {
                        Board[i, j] = 1;
                    }
                    else
                    {
                        Board[i, j] = 2;
                    }*/
                    Board[i, j] = 0;
                }
            }

            DISPLAY(Board);

        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            int level = Int32.Parse(LevelBox.Text.ToString());

            Console.WriteLine("Level je: " + level);


        }

        private void GameBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs MC = (MouseEventArgs)e;
            Point coordinates = MC.Location;

            int x, y;
            x = coordinates.X-8;
            y = coordinates.Y-8;

            Xcoord.Text = x.ToString();
            Ycoord.Text = y.ToString();
            x = (x / 210);
            y = (y / 210);
            /*
            if(Board[x, y] == 1 )
                Board[x, y] = 2;
            else if (Board[x, y] == 2)
                Board[x, y] = 1;
            */
            if(Board[x, y] == 0)
            {
                Board[x, y] = 1;
            }
            else
            {
                WarningLbl.Text = "Field x: " + x + " y: " + y + " already taken!!!" ;
            }


            DISPLAY(Board);


            int a = STATE(Board);

            if(a != 0)
            {
                if(a == 1)
                {
                    WarningLbl.Text = "Zmagal je igralec X";

                }
                if (a == 2)
                {
                    WarningLbl.Text = "Zmagal je igralec O";
                    
                }
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}