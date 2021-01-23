    private void btnNewWindow_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = true;
    }
    
    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        string id = txtID.Text;
        string name = txtName.Text;
        testList.Add(new App2.Test { id = id, name = name });
        conn.Execute(@"insert into Test values (?,?)", id, name);
        MyPopup.IsOpen = false;
    }
