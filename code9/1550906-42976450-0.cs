    for (int i = 0; i < listView1.CheckedItems.Count; i++)
    {
       if(i != 0)
       {
          // Put separator in before this thing 
          // when this is not the first thing we add.
          sqlQry.Text += radioButton9.Text;
       }
       sqlQry.Text += listView1.CheckedItems[i].Text;
    }  
