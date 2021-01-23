    private void icItem_MouseDown(object sender, MouseButtonEventArgs e)
    {
       var btn = sender as Button;
       if(btn!=null)
           MessageBox.Show(btn.Tag);
    }
