        List<string> list = new List<string>();
        list.Add("Select country");
        list.Add("USA");
        list.Add("Germany");
    
        ComboBox combobox = new ComboBox();
        combobox.ItemsSource = list;
    
        CheckBox checkbox = new CheckBox();
        ListViewItem itm;
               
        itm = new ListViewItem();
        itm.Content = "my name" as string;
        listView1.Items.Add(itm);
        itm = new ListViewItem();
        itm.Content = combobox as ComboBox;
        listView1.Items.Add(itm);
        itm = new ListViewItem();
        itm.Content = checkbox as CheckBox;
        listView1.Items.Add(itm);
