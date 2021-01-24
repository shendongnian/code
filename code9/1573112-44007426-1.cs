    //ReviewDue will never be null
    		e.Row.Cells[8].Text = Convert.ToDateTime(((DataRowView)e.Row.DataItem)["ReviewDue"]).ToString("d");
    
                    //SubmittedDate can be null, handle null 
                    object dtmDate9 = ((DataRowView)e.Row.DataItem)["SubmittedDate"];
    
                    if (dtmDate9 == DBNull.Value)
                    {
                        e.Row.Cells[9].Text = String.Empty;
                    }
                    else
                    {
                      
                        e.Row.Cells[9].Text = Convert.ToDateTime(((DataRowView)e.Row.DataItem)["SubmittedDate"]).ToString("d");
                    }
