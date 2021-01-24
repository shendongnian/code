    private void cmbKeyDown(object sender, KeyEventArgs e)
    {
        string temp = ((ComboBox)sender).Text;
        var newList = MyList.Where(x => x.Name.Contains(temp));
        MyList = newList.ToList();
    }
