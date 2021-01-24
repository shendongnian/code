    if (ListBox3.SelectedIndex >= 0)
    {
       for (int i = 0; i < ListBox3.Items.Count; i++)
        {
           if (ListBox3.Items[i].Selected)
           {
                if (!arraylist1.Contains(ListBox3.Items[i]))
                {
                    arraylist1.Add(ListBox3.Items[i]);
                    //Session["value"] = ListBox3.Items[i]; no need of this
                }
            }
        }
        for (int i = 0; i < arraylist1.Count; i++)
        {
            if (ListBox2.Items.FindByText(((ListItem)arraylist1[i]).Text)==null)
            {
    //since you already have text and value field values in arrayList. Use them
                ListBox2.Items.Add(new ListItem(arraylist1[i].Text));
    
            }
            if (ListBox1.Items.FindByText(((ListItem)arraylist1[i]).Text)==null) 
    {
    ListBox1.Items.Add(new ListItem(arraylist1[i].Value));
    }
    
    ListBox3.Items.Remove(((ListItem)arraylist1[i]));
        }
        ListBox2.SelectedIndex = -1;
    
    }
    else
    {
    
    }
    
    /* This database call can be removed
    
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand command = new SqlCommand("select * from IT_1_BOILER_DESK_1_PARAMETERS where paramtext='" + Session["value"] + "'", con);
    SqlDataAdapter dataAadpter = new SqlDataAdapter(command);
    DataSet ds = new DataSet();
    dataAadpter.Fill(ds);
    if (ds != null)
    {
        ListBox1.DataSource = ds.Tables[0];
        ListBox1.DataTextField = "param";
        //ListBox3.DataValueField = "param";
        ListBox1.DataBind();
    }*/
