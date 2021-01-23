    List<Color> ColorList = new List<Color>() { Color.Yellow, Color.Red};
    public Form1()
    {
        InitializeComponent();
        
        this.listBox1.DataSource = ColorList;
    }
    // if this event is fired you don't need to check whether an item is selected or not (no if-clause needed) 
    private void colorsLstBx_SelectedIndexChanged(object sender, EventArgs e)
    {
        // just assign the selected item and no switching is needed
        this.BackColor = (Color)listBox1.SelectedItem;
    }
