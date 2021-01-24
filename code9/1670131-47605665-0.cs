    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        if (t != null)
        {
            // Here I am making the assumption we will get suggestions after
            // 3 characters are entered
            if (t.Text.Length >= 3)
            {
                // This will get the suggestions from some place like db, 
                // table etc.
                string[] arr = GetSuggestions(t.Text);
    
                if (arr.Length == 0) {// do whatever you want to}
                else 
                {
                    var collection = new AutoCompleteStringCollection();
                    collection.AddRange(arr);
    
                    this.textBox1.AutoCompleteCustomSource = collection;
                }
            }
        }
    }
