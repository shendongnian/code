    int x;
	foreach (ListViewItem itemRow in this.listView1.Items)
 	{   
	    x = 1;
	    switch(x)
        {
            case 1:
            {
         	   for (int i = 0; i < itemRow.SubItems.Count; i++)
         	   {
           		     frm2.label1.Text = itemRow.SubItems[i].Text;
           		     frm2.label2.Text = itemRow.SubItems[i].Text;
          		     frm2.label3.Text = itemRow.SubItems[i].Text;
          		     frm2.label4.Text = itemRow.SubItems[i].Text;
         	   }
             }
	    	 case 2:
	    	 {
         	   for (int i = 0; i < itemRow.SubItems.Count; i++)
         	   {
           		     frm2.label5.Text = itemRow.SubItems[i].Text;
           		     frm2.label6.Text = itemRow.SubItems[i].Text;
          		     frm2.label7.Text = itemRow.SubItems[i].Text;
          		     frm2.label8.Text = itemRow.SubItems[i].Text;
         	   }
             }
	    x++;
        }
    }
