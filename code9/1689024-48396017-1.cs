    private void MyEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Debug.WriteLine(string.Format("old value:{0}", e.OldTextValue));
        Debug.WriteLine(string.Format("new value:{0}", e.NewTextValue));
    }
