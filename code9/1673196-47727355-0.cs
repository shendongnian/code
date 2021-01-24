            conn.Open();
            SqlCommand com = new SqlCommand("update lend set date_back=convert(datetime2, getdate(), 102) where client_name ='" + comboBox1.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter("Declare @startdate smalldatetime declare @enddate smalldatetime set @startdate = (select date_lended from dbo.lend where client_name = '" + comboBox1.Text + "') set @enddate = (select date_back from dbo.lend where client_name = '" + comboBox1.Text + "') SELECT DATEDIFF(DAY, @startdate+2, @enddate)as timepassedd", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables.Count == 1)
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        if(dr.ItemArray.Length > 0)
                        {
                            if(dr["timepassedd"] != DBNull.Value)
                            {
                                int date;
                                date = Convert.ToInt32(Dr["timepassedd"]);
                                if (date > 0)
                                {
                                    com = new SqlCommand("delete lend where client_name ='" + comboBox1.Text + "'" +
                                        "UPDATE book_list set book_stock = book_stock  1 WHERE book_name ='" + comboBox1.Text + "'", conn);
                                    com.ExecuteNonQuery();
                                    MessageBox.Show("You Returned the book " + date + " Days Late!" +
                                        "please pay the fee to the front desk");
                                    UserPanel u = new UserPanel();
                                    u.Show();
                                    this.Hide();
                                }
                                else if (date <= 0)
                                {
                                    com = new SqlCommand("delete lend where client_name ='" + comboBox1.Text + "'" +
                                        "UPDATE book_list set book_stock = book_stock  1 WHERE book_name ='" + comboBox1.Text + "'", conn);
                                    com.ExecuteNonQuery();
                                    MessageBox.Show("You Returned the book " + date + " Days Late!" +
                                        "please pay the fee to the front desk");
                                    UserPanel u = new UserPanel();
                                    u.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                }
            }
            conn.Close();
