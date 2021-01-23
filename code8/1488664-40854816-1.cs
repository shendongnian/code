    private void cboObjects_KeyDown(object sender, KeyEventArgs e)
    {
        string temp = ((ComboBox)sender).Text;
    
        var newList = MyList.Where(x => x.Name.Contains(temp));
    
        MyList = newList.ToList();
    }
