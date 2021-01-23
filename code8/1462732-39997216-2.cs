    Button[,] But = new Button[10, 10];
    public Form1()
    {
        InitializeComponent();
        Size sz = new Size(30, 30);
        for (int i = 0; i <= 9; i++)
        {
            for (int j = 0; j <= 9; j++)
            {
                But[i, j] = new Button();
                But[i, j].Size = sz;
                But[i, j].Location = new Point(sz.Width * i, sz.Height * j);
                But[i, j].Click += Buttons_Click;
                But[i, j].Tag = new Point(i, j);
                this.Controls.Add(But[i, j]);
            }
        }
    }
    private void Buttons_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        // ..
    }
