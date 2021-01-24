    PictureBox pictureBox1 = new PictureBox();
    int zoom = 1;
    Timer timer = new Timer();
    
    public Form1()
    {
        pictureBox1.Dock = DockStyle.Fill; // Occupy the full area of the form
        pictureBox1.BorderStyle = BorderStyle.FixedSingle; // Have a single border of clear representation
        Controls.Add(pictureBox1); // Add the control to the form
        FormBorderStyle = FormBorderStyle.None; // Make the form borderless to make it as lens look
    
        timer.Interval = 100; // Set the interval for the timer
        timer.Tick += timer_Tick; // Hool the event to perform desire action
        timer.Start(); //Start the timer
        printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Have a bitmap to store the image of the screen         
    }
