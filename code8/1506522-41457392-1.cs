    flag = string.Compare(excel_getValue("A" + i), "DATE");
    string[]  lat = excel_getValue("A" + i).Split();
    string[] date = excel_getValue("A" + i).Split();
  
    if (result == 0)
    {
        MessageBox.Show("Location Tracking Complete");
        // Environment.Exit(0);     // program exit
        Thread.Sleep(5000);
    }
    If (lat.count > 0)
      int LAC = Convert.ToInt32(lat[0], 16); // creating a variable MAYBE? Possible issues later
    else
      // lat is empty
