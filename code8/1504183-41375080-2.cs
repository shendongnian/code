     [System.Web.Services.WebMethod]
                public static Array LoadAssetAssignView()
                    {
                   string sql = "SELECT Time,Inuse FROM table4";
                    using (SqlConnection Connection = new SqlConnection((@"Data Source")))
                        {
                         using (SqlCommand myCommand = new SqlCommand(sql, Connection))
                            {
                                Connection.Open();
                                using (SqlDataReader myReader = myCommand.ExecuteReader())
                                {
                                    DataTable dt = new DataTable();
                                    dt.Load(myReader);
                                    Connection.Close();
                                    Page page = (Page)HttpContext.Current.Handler;
                                    TextBox TextBox1 = (TextBox)page.FindControl("TextBox1");
                                    TextBox TextBox2 = (TextBox)page.FindControl("TextBox2");
                                    Num1=TextBox1 .text;
                                    Num2=TextBox2 .text;
                       }
                  }
               }
            }
