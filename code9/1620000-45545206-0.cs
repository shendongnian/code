    DataTable table = new DataTable();
                    string data = " * ";
                    string fromTable = " Decoration ";
    
                    table = SqlHelper.LoadMyTableData(data, fromTable);
    
                    int i = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        string id = row["DecrationID"].ToString();
                        string name = row["DecorationName"].ToString();
                        string details = row["DecorationDetails"].ToString();
                        string servicesOffered = row["ServicesOffered"].ToString();
                        string imagePath = row["DecorationImagePath"].ToString();
    
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func('" + id + "')", true);
                        string scriptKey = "text" + id;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text5", "populateDecor('" + id + "','" + name + "','" + details + "','" + servicesOffered + "', '" + imagePath + "');", true);
                        i++;
                    }
