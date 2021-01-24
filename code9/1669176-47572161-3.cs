    private void button2_Click(object sender, EventArgs e)
    {
    	InitializeComponent();
        
        // Show the problem with a second call to InitializeComponent
        // The UD control moved is the second one with its handler active.
    	numericUpDown1.Location = new Point(0,0);
    }
