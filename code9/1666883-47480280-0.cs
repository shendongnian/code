     for (int d = 0; d < comDataRecNo.Length; d++)
                    {
                    
                        using (SqlConnection myCnx3 = (SqlConnection)(Dts.Connections["MDTEMP2"].AcquireConnection(Dts.Transaction) as SqlConnection))
                        {
                            SqlCommand writeCommentSQL = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[cspc2_commentswip] ([Customer No_],[Comment]) VALUES(@CustNo, @Comm)", myCnx3);
                            writeCommentSQL.Parameters.AddWithValue("@CustNo", comDataCustNo[d]);
                            writeCommentSQL.Parameters.AddWithValue("@Comm", comDataComment[d]);
 
                            writeCommentSQL.ExecuteNonQuery();
                            myCnx3.Close();
                        } 
                    }
