    private void AddNewRowToGrid()
            {
    
                int rowIndex = 0;
    
                DataTable dtCurrentTable = dt;
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
    
                        //Locate controls in GridView
                        DropDownList ddl1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("EqpCatDDL");
                        DropDownList ddl2 = (DropDownList)GridView1.Rows[rowIndex].Cells[2].FindControl("DescripDDL");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
    
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["S/N"] = dtCurrentTable.Rows.Count;
                        drCurrentRow["Column1"] = ddl1.SelectedValue;
                        drCurrentRow["Column2"] = ddl2.SelectedValue;
                        drCurrentRow["Column3"] = box3.Text;
                        drCurrentRow["Column4"] = box4.Text;
                        //add new row to DataTable
                        dtCurrentTable.Rows.Add(drCurrentRow);
    
                        //extract the TextBox values
    
                       
                        //Store the current data to ViewState
    
                        //Rebind the Grid with the current data
                        GridView1.DataSource = dtCurrentTable;
                        GridView1.DataBind();
                    }
    
    
    
                SetPreviousData(); //Set Previous Data from DataTable to GridView on Postbacks from Add New Row button click
            }
