    private void initial()
    {
        //creating DataTable  
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "ProductsSold";
    
        //creating columns for DataTable  
        dt.Columns.Add("ddl_choose_item", typeof(string));
        dt.Columns.Add("txt_price", typeof(string));
        dt.Columns.Add("txt_discount", typeof(string));
        dt.Columns.Add("txt_quantitiy", typeof(string));
        dt.Columns.Add("txt_total", typeof(string));
    
        //dr = dt.NewRow();
        //dt.Rows.Add(dr);
    
        ViewState["ProductsSold"] = dt;
        add_bill_GridView.DataSource = dt;
        add_bill_GridView.DataBind();
    }
