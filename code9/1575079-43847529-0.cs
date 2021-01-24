    int counter = 0;
    string line;
    
    System.IO.StreamReader file = new System.IO.StreamReader("cacchuongtrinhchan.txt");
    while ((line = file.ReadLine()) != null)
    {
        ListViewItem lv = new ListViewItem();
        lv.Text = line.ToString();
        listView1.Items.Add(lv);
        counter++;
    }
