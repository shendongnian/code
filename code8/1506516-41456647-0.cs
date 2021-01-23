    string[] lat;
    if (flag == 1)
    {
        string[] date = excel_getValue("A" + i).Split();
    
    }
    else if (flag != 1)
    {
        lat = excel_getValue("A" + i).Split();
    }
    if (result == 0)
    {
        MessageBox.Show("Location Tracking Complete");
        //Environment.Exit(0); // programme exit
        Thread.Sleep(5000);
    }
    int LAC = Convert.ToInt32(lat[0], 16);  //Converting to int
