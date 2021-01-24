                string initialId = Dt.Rows[0]["ID"].ToString();
        		do
        		{
        			string dCmd = "SELECT ID FROM TableA WHERE Reference_ID = '" + initialId + "'";
        			SqlDataAdapter dSda = new SqlDataAdapter();
        			dSda.SelectCommand = new SqlCommand(dCmd, nCon);
        			DataTable dDt = new DataTable();
        			
        			dSda.Fill(dDt);
        			
        			for (int i = 0; i < dDt.Rows.Count; i++)
        			{
        				initialId = dDt.Rows[i]["ID"];
        				Response.Write(dDt.Rows[i]["ID"]);
        			}
        		}
        		while(dDt.Rows.Count > 0)
