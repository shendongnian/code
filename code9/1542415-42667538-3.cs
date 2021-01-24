    public Form1()
    {
        InitializeComponent();
        pictureBox1.Paint += pictureBox1_Paint;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (pictureBox1.Image == null)
        {
            //Disable buttons
        }
        else
        {
            //Enable buttons
        }
    }
