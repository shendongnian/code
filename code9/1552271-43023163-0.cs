    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Button[] gameButtons = new Button[9]; //array of buttons for markers(X's and O's)
            bool cross = true; //cross is set to true if the next marker is to be a cross
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Text = "More Complex Version of Noughts and Crosses";
                this.BackColor = Color.BlanchedAlmond;
                this.Width = 400;
                this.Height = 400;
                for (int i = 0; i < gameButtons.Length; i++)
                {
                    int index = i;
                    this.gameButtons[i] = new Button();
                    int x = 50 + (i % 3) * 50;
                    int y = 50 + (i / 3) * 50;
                    this.gameButtons[i].Location = new System.Drawing.Point(x, y);
                    this.gameButtons[i].Name = "btn" + (index + 1);
                    this.gameButtons[i].Size = new System.Drawing.Size(50, 50);
                    this.gameButtons[i].TabIndex = i;
                    //this.gameButtons[i].Text = Convert.ToString(index);
                    this.gameButtons[i].UseVisualStyleBackColor = true;
                    this.gameButtons[i].Visible = true;
                    gameButtons[i].Click +=  new EventHandler(buttonHasBeenPressed);
                    this.Controls.Add(gameButtons[i]);
                }
            }
            private void buttonHasBeenPressed(object sender, EventArgs e)
            {
                if (((Button)sender).Text == "")
                {
                    if (cross == true)
                    {
                        ((Button)sender).Text = "X";
                        //gameButtons[i].Text = "X";
                    }
                    else
                    {
                        ((Button)sender).Text = "O";
                        //gameButtons[i].Text = 'O';
                    }
                    cross = !cross;
                }
            }
        }
    }
