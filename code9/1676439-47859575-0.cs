    string[] Arr1 = new string[] { "Game1", "Game2", "Game3" };
    string[] Arr2 = new string[] { "Vid1", "Vid2", "Vid3" };
    string[] Arr3 = new string[] { "Con1", "Con2", "Con3" };
    
    string sVal = "Vid1";
    
    if (!Arr1.Contains(sVal) && !Arr2.Contains(sVal) && !Arr3.Contains(sVal))
        MessageBox.Show("Value Does Not Exists in Any Array");
    else
    {
        if (Arr1.Any(x => x == sVal))
            MessageBox.Show("Value Exists in Array 1");
        if (Arr2.Any(x => x == sVal))
            MessageBox.Show("Value Exists in Array 2");
        if (Arr3.Any(x => x == sVal))
            MessageBox.Show("Value Exists in Array 3");
    }
