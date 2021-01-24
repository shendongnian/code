    string stringComparision = "";
    for(int i = 0; i < listBox1.Items.Count; i++)
    {
        stringComparision +="'" + listBox1.Items[i].ToString() + "',";
    }
    stringComparision = stringComparision.TrimEnd(','); // to delete last comma
