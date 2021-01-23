            string strUrl = "some url";
            using (SPWeb myWeb = new SPSite(strUrl).OpenWeb())
            {
                    SPListItemCollection items = myWeb.Lists["YourListName"].Items;
                    string fieldValue1 = "";
                    //...
                    string fieldValuen = "";
                    SqlConnection con = new SqlConnection("connection string");
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        foreach (SPListItem item in items)
                        {
                            fieldValue1 = item["column 1 name in SPList"].ToString();
                            //...
                            fieldValuen = item["column n name in SPList"].ToString();
                            string sqlCommand = "INSERT INTO TABLE_NAME(field1ColumnName, ..., fieldnColumnName) VALUES('" + fieldValue1 + "', ...,'" + fieldValue1 + "')";
                            cmd.CommandText = sqlCommand;
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                
            }
