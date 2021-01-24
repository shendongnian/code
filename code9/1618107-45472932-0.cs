    1ListView.Columns.Add("IDs");
    1ListView.Columns.Add("Internals");
    1ListView.Items.AddRange(Properties.Resources.sfxlist.Split('\r')//split the value
        .Select(val => new ListViewItem(new string[]//assign a listviewitem to each value
        { val.Substring(0, IndexOf("internal_ref")),//the subitems consist of the two values
        val.Substring(IndexOf("internal_ref")) })).ToArray());
