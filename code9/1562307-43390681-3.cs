    private void add_new_row()
        {
            if (ViewState["ProductsSold"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductsSold"];
                DataRow drCurrentRow;
    
                //if (dtCurrentTable.Rows.Count > 0)
                //{
                    //for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    //{
                        //Creating new row and assigning values  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["ddl_choose_item"] = "ddl";
                        drCurrentRow["txt_price"] = "pric";
                        drCurrentRow["txt_discount"] = "dis";
                        drCurrentRow["txt_quantitiy"] = "quan";
                        drCurrentRow["txt_total"] = "tot";
                    //}
    
                    //Added New Record to the DataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //storing DataTable to ViewState  
                    ViewState["ProductsSold"] = dtCurrentTable;
                    add_bill_GridView.DataSource = dtCurrentTable; 
                    add_bill_GridView.DataBind();
                //}
            }
        }
