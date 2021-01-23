    List<string> names = new List<string>();
    for (int i = 0; i < checkedListBox.Items.Count; i++) 
    {
        CheckState st = checkedListBox.GetItemCheckState(checkedListBox.Items.IndexOf(i));
        if(st == CheckState.Checked)
        {
            int selected = checkedListBox.SelectedIndex;
            if (selected != -1)
            {
                names.Add(checkedListBox.Items[selected].ToString());
            }
        }
    }  
