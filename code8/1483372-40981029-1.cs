    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //find the control with findcontrol and cast back to a radiobuttonlist
        RadioButtonList radioButtonList = e.Item.FindControl("RadioButtonList1") as RadioButtonList;
    
        //add some listitems, usually filled from list or database
        for (int i = 0; i < 5; i++)
        {
            radioButtonList.Items.Insert(i, new ListItem("ListItem " + i, i.ToString(), true));
        }
    
        //cast the dataitem to the datarowview
        DataRowView row = e.Item.DataItem as DataRowView;
    
        //set the correct radiobuttonvalue
        radioButtonList.SelectedValue = row["dbValue"].ToString();
    }
