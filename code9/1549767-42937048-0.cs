     public int codeUsers()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select userId from Users order by userId",connection);
            da.Fill(dt);
            var value = dt.Rows[0][0];
            if (value==DBNull.Value)
            {
                myNewIdUsers = 1;
            }
            else 
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        myNewIdUsers = Convert.ToInt32(dt.Rows[i][0]) + 1;
                        break;
                    }
                    else if (Convert.ToInt32(dt.Rows[i][0]) != Convert.ToInt32(dt.Rows[i+1][0]) - 1)
                    {
                        myNewIdUsers = Convert.ToInt32(dt.Rows[i][0]) + 1;
                        break;
                    }
                }
            }
                               
                return myNewIdUsers;
        }
 
