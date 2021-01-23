    List<Color> ColorList = new List<Color>() { Color.Yellow, Color.Red};
    public Form1()
    {
        InitializeComponent();
        
        this.listBox1.DataSource = ColorList;
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BackColor = (Color)listBox1.SelectedItem;
    }
