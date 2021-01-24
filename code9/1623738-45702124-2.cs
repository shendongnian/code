        public partial class Form1 : Form
        {
            const int WIDTH = 1200;
            const int HEIGHT = 1200;
            const int MARGIN = 200;
            const int NUMBER_OF_ROWS = 2;
            const int NUMBER_OF_COLS = 2;
            static List<DataGridView> dgvs = new List<DataGridView>();
            public Form1()
            {
                InitializeComponent();
                this.Width = WIDTH;
                this.Height = HEIGHT;
                TableLayoutPanel panel = new TableLayoutPanel();
                this.Controls.Add(panel);
                panel.Height = HEIGHT - MARGIN;
                panel.Width = WIDTH - MARGIN;
                panel.ColumnCount = NUMBER_OF_COLS;
                panel.RowCount = NUMBER_OF_ROWS;
                for (int row = 0; row < NUMBER_OF_ROWS; row++)
                {
                    for (int col = 0; col < NUMBER_OF_COLS; col++)
                    {
                        DataGridView newDGV = new DataGridView();
                        dgvs.Add(newDGV);
                        newDGV.Height = (HEIGHT - MARGIN) / NUMBER_OF_ROWS;
                        newDGV.Width = (WIDTH - MARGIN) / NUMBER_OF_COLS;
                        newDGV.Left = 50;
                        newDGV.Top = 50;
                        panel.Controls.Add(newDGV, col, row);
                    }
                }
            }
