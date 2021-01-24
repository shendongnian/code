    foreach(var item in listBox1.Items)
    {
      for(int i = 0; i < checkedListBox1.Items.Count; i++)
    {
     checkedListBox1.SetItemChecked(i, false);//First uncheck the old value!
     //
      for (int x = 0; x < checkedListBox1.Items.Count; x++)
     {
           if (checkedListBox1.Items[i].ToString() == listBox1.Items.ToString())
           {
               //Check only if they match! 
               checkedListBox1.SetItemChecked(i, true); 
           }
    }
