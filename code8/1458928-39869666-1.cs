    public void backgroundWorkerXY_ProgressChanged(object sender, object sender1, ProgressChangedEventArgs e)
    {
        var args = (Tuple<int, int>)e.UserState;
        pictureBox1.Location = new Point(args.Item1, args.Item2) );
    }
