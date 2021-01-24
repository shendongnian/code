    var lines = File.ReadAllLines("records.txt");
    for(int i = 0; i < lines.Length; i++)
    {
       var line = lines[i];
       if(line.Contains(txt_SearchBooking.Text))
       {
           //Retrieve the previous lines
           for(int y = i-8; y <= i; y++)
           {               
               lbl_result.Text += lines[y];
           }
       }
    }
