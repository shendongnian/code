    public bool x = false;
    public bool j = false;
    private void Preiststop_Click(object sender, EventArgs e)
    {
        j = true;
    }
    private void Preist_Click(object sender, EventArgs e)
    {
        x = true;
    
        Thread newThread = new Thread(delegate ()
        {
            DoPriestWork();
        });
    
        newThread.Start();
    
        //loop to wait for the response from DoPriestWork thread
        while (x)
        {
            Thread.Sleep(5000);
            if (j)
                x = false;
        }
    
        newThread.Abort(); 
    }
    public void DoPriestWork()
    {
        //x = true;
        //while (x == true)
        //{
        SendKeys.Send(" ");
        //Thread.Sleep(5000);
        //    if (j == true)
        //        x = false;
        //}
    }
