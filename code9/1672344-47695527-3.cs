    Try This Would Be Prefect
    private void btnSave_Click(object sender, EventArgs e)
    {
        //SQL statement set to Add a new value
            sql = String.Format("INSERT INTO " + table1 + "(Account_Code,Address1,Address2,Address3,Balance,Sales_Year_To_Date,Cost_Year_To_Date) " +
                                 "VALUES " + (@acctCode, @address1, @address2, @address3, @balance, @yearSales, @yearCost));
            sql2 = String.Format("INSERT INTO " + table2 + "([Date],Transaction_Type,Document_No,Gross_Transaction_Value,Vat_Value)" +
                                 "VALUES " + (@date, @transaction, @docNum, @grossVal, @vatVal));
            
            try
            {
                dbConn = new OleDbConnection(conString);
                cmd = new OleDbCommand(sql, dbConn);
                //table 1
                cmd.Parameters.AddWithValue("@acctCode", tbAcctCode.Text);
                cmd.Parameters.AddWithValue("@address1", tbAdd1.Text);
                cmd.Parameters.AddWithValue("@address2", tbAdd2.Text);
                cmd.Parameters.AddWithValue("@address3", tbAdd3.Text);
                cmd.Parameters.AddWithValue("@balance", tbBalance.Text);
                cmd.Parameters.AddWithValue("@yearSales", tbSales.Text);
                cmd.Parameters.AddWithValue("@yearCost", tbCost.Text);
                dbConn.Open();
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand(sql2, dbConn);
                //table 2
                cmd.Parameters.AddWithValue("@date", tbDate.Text);
                cmd.Parameters.AddWithValue("@transaction", tbTrans.Text);
                cmd.Parameters.AddWithValue("@docNum", tbDocNum.Text);
                cmd.Parameters.AddWithValue("@grossVal", tbGross.Text);
                cmd.Parameters.AddWithValue("@vatVal", tbVat.Text);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
                MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConn.Close();
            }
        }
