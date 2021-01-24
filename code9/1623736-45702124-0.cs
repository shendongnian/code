           public Form1()
            {
                InitializeComponent();
                TableLayoutPanel panel = new TableLayoutPanel();
                this.Controls.Add(panel);
                panel.Height = 1000;
                panel.Width = 1000;
                panel.ColumnCount = 2;
                panel.RowCount = 2;
                DataGridView dgv1 = new DataGridView();
                dgv1.Height = 400;
                dgv1.Width = 400;
                dgv1.Left = 50;
                dgv1.Top = 50;
                panel.Controls.Add(dgv1, 0, 0);
                DataGridView dgv2 = new DataGridView();
                dgv2.Height = 400;
                dgv2.Width = 400;
                dgv2.Left = 50;
                dgv2.Top = 50;
                panel.Controls.Add(dgv2, 1, 0);
                DataGridView dgv3 = new DataGridView();
                dgv3.Height = 400;
                dgv3.Width = 400;
                dgv3.Left = 50;
                dgv3.Top = 50;
                panel.Controls.Add(dgv3, 0, 1);
                DataGridView dgv4 = new DataGridView();
                dgv4.Height = 400;
                dgv4.Width = 400;
                dgv4.Left = 50;
                dgv4.Top = 50;
                panel.Controls.Add(dgv4, 1, 1);
            }
