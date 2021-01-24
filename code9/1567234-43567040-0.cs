    private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        //do list sorting here ex.)
        List<string> FilteredResults = SomeList<string>.where(i => i.Contains(textbox.text)).ToList();
    }
