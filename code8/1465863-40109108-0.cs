    if (!string.IsNullOrWhiteSpace(computed))
                {
                    connect.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connect;
                    command.CommandText = "update Table1 set ot='" + computed + "' where Fname = '" + uname + "' ";
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Save Complete");
                }
