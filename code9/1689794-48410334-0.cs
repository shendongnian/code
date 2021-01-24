    private void Option1_MouseDown(object sender, MouseEventArgs e)
    {
        var dc = (sender as Image).DataContext;
        DataRowView row = (DataRowView) dc;
        String URL = Convert.ToString(row.Row["ID"]);
    
        int newState = myQuery.UpdateIsTogglable(rowID);
    
        if (newState)
            (sender as Image).Source =
                 new BitmapImage(new Uri(@"/myProject;component/Images/Option1_true.png", UriKind.Relative));
        else 
            (sender as Image).Source =
                 new BitmapImage(new Uri(@"/myProject;component/Images/Option1_false.png", UriKind.Relative));
    }
