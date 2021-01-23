    GrdDynamic.DataSource = dt;    
    GrdDynamic.DataBind();
    int rowIndex=2;
    GrdDynamic.FooterRow.Cells[1].Text = "Total";
    GrdDynamic.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    foreach (DataColumn col in dt.Columns)
    {
       decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>(col.Caption));
       GrdDynamic.FooterRow.Cells[rowIndex++].Text = total.ToString("N2");
    } 
    
