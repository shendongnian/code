    var command = @"Select Pur_Entry_Date, Pur_Invoice_No, Supplier_Bill_No, Product.Item_Name, Pur_Item_Batch_No, Item_Batch_Expiry, Pur_Item_PackQuantity, Pur_Bonus_LooseQuantity, MRP_Final, Purchase_Pack_Price, Discount_Percentage, Extra_Discount_Percentage, SalesTax_Percent, Pur_Item_Total_Amount 
                    from purchase  
                    LEFT OUTER JOIN product on Purchase.Item_Code = Product.Item_Code 
                    where Purchase.Pur_Entry_Date BETWEEN @p1 AND @p2 
                    order by purchase.Pur_Entry_Date";
    using(var cmd = new SqlCommand(cmd, ConnectionDAC.GetConnection()))
    {
       cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dateTimePicker1.Value;
       cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = dateTimePicker2.Value;
    
       using(var adp = new SqlDataAdapter(cmd))
       {
           adp.Fill(dt);
       }
    
       if (dt.Rows.Count == 0)
       {
           label8.Text = "Zero Rows found";
       }
       else
       {
          dataGridView1.Rows.Clear();
          label8.Text = totalrows.ToString();
          dataGridView1.DataSource = dt;
       }
    }
