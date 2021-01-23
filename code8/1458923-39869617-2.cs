    public void backgroundWorkerXY_ProgressChanged(
        object sender, 
        ProgressChangedEventArgs e)
    {
        var my = (MyCustomClass)e.UserState;
        pictureBox1.Location = new Point(my.X, my.Y);
    }
