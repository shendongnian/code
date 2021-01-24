    for (int i = 0; i < comboBox1.Items.Count; i++)
    {
        string st = comboBox1.Items[i].ToString();
        if (st == "svchost")
        {               
            comboBox1.Items.RemoveAt(i);
            i--;                    
        }
    }
