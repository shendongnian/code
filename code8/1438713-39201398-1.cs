            string fieldValue1 = ""; 
            //...
            string fieldValuen = "";        
            foreach (var item in items)
            {
                fieldValue1 = item["column 1 name in SPList"].ToString();
                //...
                fieldValuen = item["column n name in SPList"].ToString();
            }
            string sqlCommand = "INSERT INTO TABLE_NAME(field1ColumnName, ..., fieldnColumnName) VALUES('" + fieldValue1 + "', ...,'" + fieldValue1 + "')";
            SqlConnection con = new SqlConnection("connection string");
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            cmd.ExecuteNonQuery()
