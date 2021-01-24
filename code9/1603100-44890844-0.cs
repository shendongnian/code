    for(int i = 0; i < checkedListBox1.Items.Count; i++)
    {
        Int_String s = checkedListBox1.Items[i] as Int_String;
        if(primalacID.Contains(s._int))
        {
            checkedListBox1.SetItemChecked(i, true);
        }
    }
