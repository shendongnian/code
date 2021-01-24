     con.Open();
                
    string selectSQLC = "select sum(Charges) from Kitchen where Customer_ID=@Customer_ID and Date Between @date1  and @date2";
    
    SqlCommand cmdCC = new SqlCommand(selectSQLC, con);
    SqlParameter param  = new SqlParameter();
			param.ParameterName = "@Customer_ID";
			param.Value         = txtCustomerID.Text;
    SqlParameter paramd1  = new SqlParameter();
			paramd1.ParameterName = "@date1";
			paramd1.Value         = dateofarrival;
    SqlParameter paramd2  = new SqlParameter();
			paramd2.ParameterName = "@date2";
			paramd2.Value         = DateTime.Now;
    cmdCC.Parameters.Add(param);
    cmdCC.Parameters.Add(paramd1);
    cmdCC.Parameters.Add(paramd2);
     SqlDataReader rdCC;
    rdCC = cmdCC.ExecuteReader();
    
    while (rdCC.Read())
    {
        KitchenBill = rdCC.GetInt32(0);
    }
    
    TotalAmount = KitchenBill + TotalAmount;   
    
    con.Close();
 
