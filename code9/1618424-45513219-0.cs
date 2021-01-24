            string value = "2723022"; // <== any reference id from Reference_id column
            String gCmd = "SELECT DISTINCT Reference_id FROM myTable WHERE User_id >'" + value + "'";
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = new SqlCommand(gCmd, nCon);
            DataTable Dt = new DataTable();
            Sda.Fill(Dt);
            for (int count = 0; count < Dt.Rows.Count; count++)
            {
                string dCmd = "SELECT User_id FROM dEmo_aCcounts WHERE Reference_id = '" + Dt.Rows[count]["Reference_id"] + "'";
                SqlDataAdapter dSda = new SqlDataAdapter();
                dSda.SelectCommand = new SqlCommand(dCmd, nCon);
                DataTable dDt = new DataTable();
                dSda.Fill(dDt);
                for (int i = 0; i < dDt.Rows.Count; i++)
                {
                    Response.Write(dDt.Rows[i]["User_id"]);
                }
            }
