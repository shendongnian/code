    protected void Button2_Click(object sender, EventArgs e)
    {
        if(ListBox2.SelectedIndex >= 0)
        {
            for(int i = 0;i < ListBox2.Items.Count; i++)
            {
                if(ListBox2.Items[i].Selected)
                {
                    if(!arraylist2.Contains(ListBox2.Items[i]))
                    {
                        arraylist2.Add(ListBox2.Items[i]);
                    }
                }
            }
            for(int i = 0;i < arraylist2.Count; i++)
            {
                if(!ListBox2.Items.Contains(((ListItem)arraylist2[i])))
                {
                    ListBox1.Items.Add(((ListItem)arraylist2[i]));
                }
                ListBox2.Items.Remove(((ListItem)arraylist2[i]));
            }
            ListBox1.SelectedIndex = -1;
    
        // Construct the query with where clause
        string whareClause = string.Join("','", arraylist2.Select(e=>e.Value));
        string query = "select * from ListBox2 where items in ('"+ whareClause + "')";
    
        // Call your db using Ade.net
        // Bind your result to new list box
    
        }
        else
        {
    
        }
    }
