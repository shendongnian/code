    private void B_Click(object sender, EventArgs e)
    {
        bool clickFlag = false;
        void Click(object sender2, EventArgs e2)
        {
            clickFlag = true;
        }
        b2.Click += Click;
        while (!clickFlag)
        {
            Thread.Sleep(1);
        }
        b2.Click -= Click;
        //Continue with your stuff
    }
