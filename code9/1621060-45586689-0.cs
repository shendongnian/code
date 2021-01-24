    try
    {
        bool success = false;
        using (var myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\HP8200\\Desktop\\ELISA2014Data.mdb ;Persist Security Info=False;"))
        {
            // Create Oledb command to execute particular query
            using (var myCommand = new OleDbCommand())
            { 
                myCommand.Connection = myConnection;
    
                // Query to create table with specified data columne
                //myCommand.CommandText = "CREATE TABLE UXZona([IDZona] int, [Morada] text)";
                //myCommand.ExecuteNonQuery();
                //MessageBox.Show("Tabela criada");
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO UXZona (IDZona, Morada) VALUES (@id, @morada)"; 
                var param = cmd.CreateParameter();
                param.ParameterName = "@id";
                param.OleDbType = OleDbType.Integer;
                param.Value = transaction.UnloadPlaceAddress.AddressID;
                cmd.Parameters.Add(param);
                param = cmd.CreateParameter();
                param.ParameterName = "@morada";
                param.OleDbType = OleDbType.VarChar;
                param.Value = transaction.UnloadPlaceAddress.AddressLine2;
                cmd.Parameters.Add(param);
                myConnection.Open();
    
                if (cmd.ExecuteNonQuery() == 1)
                {
                    success = true;
                }
            }
        }
        if (success)
        {       
            MessageBox.Show("Dados inseridos");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
