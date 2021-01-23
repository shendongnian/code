    bool a = listBox1.Items.Cast<string>().Any(x => x == "some text"); // If any of listbox1 items contains some text it will return true.
    if (a) // then here we can decide if we should add it or inform user
    {
        MessageBox.Show("Already have it"); // inform
    }
    else
    {
        listBox1.Items.Add("some text"); // add to listbox
    }
