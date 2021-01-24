    using (OracleConnection conn = new OracleConnection(connstr))
    using (OracleCommand cmd = new OracleCommand(cmdtxt01, conn))
    {
        try
        {
            conn.Open();
    
            cmd.CommandText = cmdtxt01;
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add(":vORDER_ID", OracleDbType.Int32, ParameterDirection.ReturnValue);
    
            cmd.Parameters.Add(new OracleParameter(":P_CUSTOMER_ID", OracleDbType.Int32)).Value = TB_CUSTOMER_ID.Text;
            cmd.Parameters.Add(new OracleParameter(":P_ORDER_NOTE", OracleDbType.Varchar2)).Value = TB_ORDER_NOTE.Text;
            cmd.Parameters.Add(new OracleParameter(":P_CREATED_BY", OracleDbType.Varchar2)).Value = "SYSTEM";
            //excute first SP
            cmd.ExecuteNonQuery();
            //get the value
            TB_INVOICE_ID.Text = cmd.Parameters[":vORDER_ID"].Value.ToString();
            int INVOICE_ID;
            // parse return value
            int.TryParse(TB_INVOICE_ID.Text, out INVOICE_ID);
            
            // now set 2nd SP 
            cmd.CommandText = cmdtxt02;
            cmd.CommandType = CommandType.StoredProcedure;
    
            foreach (DataGridViewRow Row in DGV_INVOICE.Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter(":P_ORDER_ID", OracleDbType.Int32)).Value = INVOICE_ID;
                cmd.Parameters.Add(new OracleParameter(":P_PRODUCT_ID", OracleDbType.Int32)).Value = Row.Cells[DGV_INVOICE.Columns["DGV_PRODUCT_ID"].Index].Value;
                cmd.Parameters.Add(new OracleParameter(":P_UNIT_PRICE", OracleDbType.Int32)).Value = Row.Cells[DGV_INVOICE.Columns["DGV_UNIT_PRICE"].Index].Value;
                cmd.Parameters.Add(new OracleParameter(":P_QUANTITY", OracleDbType.Int32)).Value = Row.Cells[DGV_INVOICE.Columns["DGV_QUANTITY"].Index].Value;
                cmd.Parameters.Add(new OracleParameter(":P_DISCOUNT", OracleDbType.Int32)).Value = Row.Cells[DGV_INVOICE.Columns["DGV_DISCOUNT"].Index].Value;
                cmd.Parameters.Add(new OracleParameter(":P_ORDER_STATUS", OracleDbType.Varchar2)).Value = '1';
                cmd.Parameters.Add(new OracleParameter(":P_ITEM_NOTE", OracleDbType.Varchar2)).Value = Row.Cells[DGV_INVOICE.Columns["DGV_ITEM_NOTE"].Index].Value;
                cmd.Parameters.Add(new OracleParameter(":P_CREATED_BY", OracleDbType.Varchar2)).Value = "SYSTEM";
    
                cmd.ExecuteNonQuery();
            }
    
    
        }
        catch (Exception EX)
        {
            MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
