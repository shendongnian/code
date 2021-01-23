    string sSQL = @"INSERT INTO characters VALUES(0,@message);";
                ArrayList parameter = new ArrayList();
                AddParameter(new MySqlParameter("@message", MySqlDbType.String), textBox1.Text, ref parameter);
                try
                {
                    var data = mySQLCommand.Instance.ExecuteScalarSQLCommand(sSQL, parameter);
    
                    MessageBox.Show("Save!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.ToString()
                        );
                }
