    DataTable dt=new DataTable();
    
    DataColumn clm0=new DataColumn("ColumnHeader",typeof(string))
    .
    .
    
    dt.Columns.Add(clm0);
    .
    .
    
    foreach(DataRow item in Products.Rows)
    {
    DataRow new_row=dt.NewRow();
    
    new_row["ColumnHeader"]=item["Column"]
    dt.Rows.Add(new_row);
    }
    
    dgvProdInformation.DataSource=dt;
