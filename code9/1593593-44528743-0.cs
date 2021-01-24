    public Form1 ()
    {
        InitializeComponent();
    }
    private void chart1_Click ( object sender, EventArgs e )
    {
        string rx_str_copy = "-128.00";
        chart1.Series["Series1"].Points.AddXY(-1.00, Convert.ToDouble(rx_str_copy));
    }
