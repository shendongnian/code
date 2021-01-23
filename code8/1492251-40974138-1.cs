        [WebMethod]
        public static string AddJSon(JsonDataList jsonDataList)
        {
            try
            {
                using(SqlConnection con=new SqlConnection("your_connection_String"))
                {
				    con.Open();
                    foreach(JsonData data in jsonDataList)
                    {
                        string query  = "INSERT into table (column1,column2,column3,...) VALUES (@value1,@value2,@value3,..)";
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.Add("@value1",data.SalesOrderItemId);
                        command.Parameters.Add("@value2",data.AttachmentCode );
                        command.Parameters.Add("@value3",data.AttachmentName );
                        .
                        .
                        command.ExecuteNonQuery();
                    }     
                }
                return "Success";
            }catch(Exception e)
            {
                return "Error";
            }
        }
