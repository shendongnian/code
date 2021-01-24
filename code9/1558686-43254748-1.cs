    string[] nameArray = { "name1", "name2", "name3", "bla name" };
    AutoCompleteTextBox tb = new AutoCompleteTextBox();
    tb.Values = nameArray;
    tb.Location = new Point(10,10);
    tb.Size = new Size(25,75);
    this.Controls.Add( tb );
