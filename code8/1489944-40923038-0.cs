        string [] array = new string[6];
        int count = 0;
        string selected = "";
        
        string QID;
        foreach (GridViewRow row in GridView3.Rows)
            {
           
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            
            // get the selected AutoId and cells text
            if (chk.Checked)
                {
                count += 1;
             QID = GridView3.DataKeys[row.DataItemIndex].Values["Q_Multiple_ID"].ToString();
                selected += QID;
               if(count <= 5)
                {
                    array[count] = QID;
                    
                    Response.Write(array[5]);
                }
                else
                {
                    chk.Checked = false;
                }
            }
            test.Text = selected;
        }
        
    }
