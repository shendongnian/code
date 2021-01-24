    if (listBox1.Items.Count < 4) {
        listBox1.Items.Add(comboBox1.Text);
    } else {
        System.Windows.Forms.MessageBox.Show("Too many");
    }
    string[] ListItemsArray= new string[4];
    listBox1.Items.CopyTo(ListItemsArray, 0);
    //Then you can leave this here:
    string One   = ListItemsArray[0] ?? "";
    string Two   = ListItemsArray[1] ?? "";
    string Three = ListItemsArray[2] ?? "";
    string Four  = ListItemsArray[3] ?? "";
