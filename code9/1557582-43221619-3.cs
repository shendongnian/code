    private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["UserDetail"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["UserDetail"];
                DataRow drCurrentRow = null;
    
                if (dtCurrentTable.Rows.Count > 0)
                {
                    //this will add previously added entries 
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
    
                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        //you can add data from textbox or other user control
                        drCurrentRow["SrNo"] = "2";
                        drCurrentRow["EmailId"] = "test@gmail.com";
                        drCurrentRow["Password"] = "Password";
    
                    }
                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
    
                    }
    
                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Save Data table into view state after creating each row  
                    ViewState["UserDetail"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }
    protected void btAgregaT_Click(object sender, EventArgs e)
    {
        AddNewRecordRowToGrid();  
    }
