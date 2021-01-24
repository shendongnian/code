    public List<Color> colors  = new List<Color> {
        Color.Red,
        Color.DarkRed,
        Color.Orange
    };
    private int current;
    public Form1() {
        InitializeComponent();
        Timer t = new Timer();
        t.Interval = 250;
        t.Tick += T_Tick;
        t.Start();
    }
    private void T_Tick(object sender, System.EventArgs e) {
        this.BackColor = colors[current++];
        current %= colors.Count;
    }
