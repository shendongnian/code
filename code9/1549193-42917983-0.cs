                DataTable dataTable=new DataTable();
                using (SqlConnection connection = new SqlConnection(*<YourConnectionString>*))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAmount", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dataTable);
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                var control=Controls.Cast<Control>().FirstOrDefault(x=>x.ID==string.Format("txt_ID{0}",dr["ID"])) as TextBox;
                                if (control != null)
                                    control.Text = dr["Amount"].ToString();
                            }
                        }
                    }
                }
