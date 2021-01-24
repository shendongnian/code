    SqlConnection con = new SqlConnection(conString);
    SqlCommand cmd1,cmd2;
    con.Open();
    cmd1 = new SqlCommand("sp1",con);
    cmd2 = new SqlCommand("sp2",con);
    SqlTransaction trans = con.BeginTransaction();
    cmd1.Transaction = trans;
    cmd2.Transaction = trans;
      try
                    {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    trans.Commit();
    
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }
