    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication13
    {
        public partial class Form1 : Form
        {
            Panel[,] _chessBoardPanels = null;
            public Form1()
            {
                InitializeComponent();
                const int tileSize = 50;
                const int gridSize = 8;
                var clr1 = Color.Black;
                var clr2 = Color.White;
                // initialize the "chess board"
                _chessBoardPanels = new Panel[gridSize, gridSize];
                // double for loop to handle all rows and columns
                for (var n = 0; n < gridSize; n++)
                {
                    for (var m = 0; m < gridSize; m++)
                    {
                        // create new Panel control which will be one 
                        // chess board tile
                        var newPanel = new Panel
                        {
                            Size = new Size(tileSize, tileSize),
                            Location = new Point(tileSize * n, tileSize * m)
                        };
                        // add to Form's Controls so that they show up
                        Controls.Add(newPanel);
                        // add to our 2d array of panels for future use
                        _chessBoardPanels[n, m] = newPanel;
                        // color the backgrounds
                        if (n % 2 == 0)
                            newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                        else
                            newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                    }
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                    int[] x = new int[] { 1, 5, 6, 7, 3, 0, 2 };
                    for (int i = 0; i < 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                {
                                    _chessBoardPanels[x[i], i].BackColor  = Color.Red;
                                    break;
                                }
                        }
                    }
            }
        }
    }
