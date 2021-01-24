	string query5 = "SELECT * FROM[PhoneTableSql] WHERE[district] = '5' AND([religion] = @religionVar1 OR[religion] = '4')";
	string query6 = "SELECT * FROM[PhoneTableSql] WHERE[district] = '6' AND([religion] = @religionVar2 OR[religion] = '4')";
        using (SqlConnection con = new SqlConnection(@"Data Source=CATISERVER1\SQLEXPRESS;Initial Catalog=dsa;Persist Security Info=True;User ID=mcsager;Password=*******"))
        {
            try
            {                    
                SqlCommand cmd5 = new SqlCommand(query5, con);
                cmd5.Parameters.AddWithValue("@religionVar1", 1);
                SqlCommand cmd6 = new SqlCommand(query6, con);
                cmd6.Parameters.AddWithValue("@religionVar2", 1);
                SqlDataAdapter adpter5 = new SqlDataAdapter(cmd5);
                adpter5.Fill(MyAppManager.ChangeFactorWeightsInstance.DtDistrict_5);
                SqlDataAdapter adpter6 = new SqlDataAdapter(cmd6);
                adpter6.Fill(MyAppManager.ChangeFactorWeightsInstance.DtDistrict_6);
            }
            catch{}
        }
