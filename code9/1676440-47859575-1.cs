    string[] Arr1 = new string[] { "Game1", "Game2", "Game3" };
    string[] Arr2 = new string[] { "Vid1", "Vid2", "Vid3" };
    string[] Arr3 = new string[] { "Con1", "Con2", "Con3" };
    string sVal = "Vid1";
    Boolean in1 = Arr1.Contains(sVal);
    Boolean in2 = Arr2.Contains(sVal);
    Boolean in3 = Arr3.Contains(sVal);
    if (!in1 && !in2 && !in3)
        MessageBox.Show("Value Does Not Exists in Any Array");
    else
    {
        if (in1)
            MessageBox.Show("Value Exists in Array 1");
        if (in2)
            MessageBox.Show("Value Exists in Array 2");
        if (in3)
            MessageBox.Show("Value Exists in Array 3");
    }
    // Output: Value Exists in Array 2
