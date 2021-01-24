        private void btnClientSave_Click(object sender, EventArgs e)
        {
            
            string oradb = "DATA SOURCE = larry.uopnet.plymouth.ac.uk:1521/orcl.fost.plymouth.ac.uk;PERSIST SECURITY INFO = True;USER ID = xxxxxxxxx;password = xxxxxxxx";
            string insertquery = "Insert into Client VALUES (:1, :2, :3, :4, :5, :6, :7)";
            
            OracleConnection con = new OracleConnection(oradb);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = insertquery;
            try
            {
                cmd.Parameters.Add(new OracleParameter("1", OracleDbType.Decimal, ParameterDirection.ReturnValue));
                cmd.Parameters.Add(new OracleParameter("2", OracleDbType.Varchar2, txtBoxClientName.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("3", OracleDbType.Varchar2, txtBoxClientCity.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("4", OracleDbType.Varchar2, txtBoxClientCountry.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("5", OracleDbType.Varchar2, txtBoxClientNumber.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("6", OracleDbType.Varchar2, txtBoxClientURL.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("7", OracleDbType.Varchar2, comboClientStatus.Text, ParameterDirection.Input));
                                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client has been added");
                con.Close();
                Close();
            }
            catch (OracleException e1)
            {
                MessageBox.Show("Error: " + e1.Message);
            }
            catch (ArgumentException e2)
            {
                MessageBox.Show("Error: " + e2.Message);
            }
            finally
            {                
                cmd.Dispose();
                con.Dispose();
            }
