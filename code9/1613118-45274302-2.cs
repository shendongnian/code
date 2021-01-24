    //read the file
    System.IO.StreamReader file =
                   new System.IO.StreamReader("yourFileName.txt");
    
    //set list view in details mode
    listView1.View = View.Details;
    
            //Set columns in listview
            listView1.Columns.Add("Date Time");
            listView1.Columns.Add("X");
        listView1.Columns.Add("Y");
        listView1.Columns.Add("Z");
    
           //read text file line by line.     
           while ((line = file.ReadLine()) != null)
           {
        myClass mc = new myClass();
        mc.DT = Convert.ToDateTime(line.ToString().Split(';')[0]);
        mc.X = Convert.ToDecimal(line.ToString().Split(';')[1]);
        mc.Y = Convert.ToDecimal(line.ToString().Split(';')[2]);
        mc.Z = Convert.ToDecimal(line.ToString().Split(';')[3]);
        listView1.Items.Add(mc);
                }
                file.Close();      
