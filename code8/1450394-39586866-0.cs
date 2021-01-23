    string tmp1, tmp2;
                    tmp1 = addfrm.getTableName();
                    tmp2 = addfrm.getType();
        
                    string constring = @"Data Source=" + adr + ";Initial Catalog=" + dat + ";User ID=" + user + ";Password=" + pwd;
                    try
                    {
                        using (SqlConnection con = new SqlConnection(constring))
                        {
                            string tmp = @"ALTER TABLE " + tbl + " SET Col1 = '" + temp1 +"',Col2='" + tmp2 "'";
        
                            Console.WriteLine("Mein Befehl lautet: " + tmp);
        
                            using (SqlCommand cmd = new SqlCommand(tmp, con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
        
                                }
                            }
                        }
                    }
                    catch (SqlException) { MessageBox.Show("Fehler"); }
