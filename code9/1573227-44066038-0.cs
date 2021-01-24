    public void getFileData()
        {
            try
            {
    		
                Uri CSVUri = new Uri("URL");
                WebRequest = (HttpWebRequest)HttpWebRequest.Create(CSVUri);
                webResponse = (HttpWebResponse)WebRequest.GetResponse();
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    System.IO.StreamReader strReader = new System.IO.StreamReader(WebRequest.GetResponse().GetResponseStream());
                    //create datatable with column names (Headers)
                    Createtable(strReader.ReadLine());
                    String SingleLine;
                    while ((SingleLine = strReader.ReadLine()) != null)
                    {
                        AddRowtable(SingleLine); //Add data into dataset
                    }
    
                    GridView1.DataSource = datatable1;
    				
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        foreach (DataColumn c in datatable1.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
    
                        bulkCopy.DestinationTableName = "dbo.tableName";
                        try
                        {
                            bulkCopy.WriteToServer(datatable1);
                        }
                        catch (Exception ex)
                        {
                            string display = "Exception Occured";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                        }
                    }
    
                    if (strReader != null) strReader.Close();
                }
            }
            catch (System.Net.WebException ex)
            {
                string display = "Exception Occured";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }
