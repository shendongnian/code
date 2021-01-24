     <asp:FileUpload ID="fuManual" Enabled="false" runat="server"  />
      <asp:Button ID="btnUploadDoc" Text="Upload" runat="server" OnClick="UploadDocument"  />
  
         public void UploadDocument(object sender, EventArgs e)
            {
            try
            {
                
                if (fuManual.HasFile)
                {
                    
                    string manual_filename = ddlStore.SelectedItem.Text + "_" + "Manual.xlsx";
                    string extension = Path.GetExtension(fuManual.PostedFile.FileName);
                    // Import Excel Code for Manual Excel Data import....
                    string FilePath = Server.MapPath("~/Temp/" + manual_filename);
                    fuManual.SaveAs(FilePath);
                    System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
                                "Provider=Microsoft.ACE.OLEDB.12.0; " +
                                 "data source='" + FilePath + "';" +
                                    "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
                    myConnection.Open();
                    DataTable mySheets = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    DataSet ds_manualData = new DataSet();
                    DataTable dt_manualData;
                    for (int i = 0; i < mySheets.Rows.Count; i++)
                    {
                        dt_manualData = makeDataTableFromSheetName(FilePath, mySheets.Rows[i]["TABLE_NAME"].ToString());
                        ds_manualData.Tables.Add(dt_manualData);
                    }
                    ViewState["ManualData"] = ds_manualData;
                    DataTable dts = new DataTable();
                    dts = ds_manualData.Tables[0];
                    //here u have the whole excel file in the data table now send it to the database  
                   //remember to send table u need SqlDbType-structured
                     
                   myConnection.Close();
                }
                else
                {
                    lblError.Text = "please Select the file to be uploaded";
                }
            }
            catch (Exception ex)
            {
            }                                    
        }
        private static DataTable makeDataTableFromSheetName(string FilePath, string sheetName)
        {
            System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(
            "Provider=Microsoft.ACE.OLEDB.12.0; " +
            "data source='" + FilePath + "';" +
            "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ");
            DataTable dtImport = new DataTable();
            System.Data.OleDb.OleDbDataAdapter myImportCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "]", myConnection);
            myImportCommand.Fill(dtImport);
            return dtImport;
        }
