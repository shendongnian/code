    public Form1()
    {
        //InitializeComponent();
        var Car = new PictureBox { Parent = this, BackColor = Color.Green };
        this.Click += async (s, e) =>
        {
            for (int i = 0; i < 100; i++)
            {
                Car.Top++;
                await Task.Delay(50);
            }
        };
    }
