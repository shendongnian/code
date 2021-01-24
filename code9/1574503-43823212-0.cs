    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication26
    {
        public partial class Form1 : Form
        {
            const string IMAGE_FILENAME = @"c:\temp\image1.jpg";
            const int NUMBER_OF_CHART_COLUMNS = 8;
            const int NUMBER_OF_CHART_ROWS = 8;
            const int MAIN_PANEL_TOP = 20;
            const int MAIN_PANEL_LEFT = 20;
            const int MAIN_PANEL_WIDTH = 1000;
            const int MAIN_PANEl_HEIGHT = 1000;
            const int CHART_LEFT = 20;
            const int CHART_TOP = 20;
            const int CHART_WIDTH = 100;
            const int CHART_HEIGHT = 100;
            const int CHART_SPACE = 10;
            List<MyChart> charts = new List<MyChart>();
            public Form1()
            {
                InitializeComponent();
                Panel mainPanel = new Panel();
                mainPanel.Left = MAIN_PANEL_LEFT;
                mainPanel.Top = MAIN_PANEL_TOP;
                mainPanel.Height = MAIN_PANEl_HEIGHT;
                mainPanel.Width = MAIN_PANEL_WIDTH;
                this.Controls.Add(mainPanel);
                for(int row = 0; row < NUMBER_OF_CHART_ROWS; row++)
                {
                    for (int col = 0; col < NUMBER_OF_CHART_COLUMNS; col++)
                    {
                        MyChart newChart = new MyChart();
                        newChart.row = row;
                        newChart.col = col;
                        newChart.Width = CHART_WIDTH;
                        newChart.Height = CHART_HEIGHT;
                        newChart.Left = col * (CHART_WIDTH + CHART_SPACE);
                        newChart.Top = row * (CHART_HEIGHT + CHART_SPACE);
                        newChart.Image = Image.FromFile(IMAGE_FILENAME);
                        mainPanel.Controls.Add(newChart);
                        charts.Add(newChart);
                    }
                }
            }
        }
        public class MyChart : PictureBox 
        {
            public int row { get; set; }
            public int col { get; set; }
        }
    }
