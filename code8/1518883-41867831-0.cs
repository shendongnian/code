        //you must make a class named data, and this class will be bind to GridView1.DataSource
    //this is a new line
        private static List<data> datasources = new List<data>();
        
        protected void Button1_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName) == ".xlsx")
                    {
                        ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
        datasources.add(package.ToDataTable()); // keep ToDataTable return type is same with data
    //here have some edit
                        GridView1.DataBind();
                    }
        
                    if (FileUpload1.FileName.Contains("0446") == true)
                    {
                        Name = Convert.ToString(GridView1.Rows[6].Cells[0].Text);
                        Name2 = Convert.ToString(GridView1.Rows[6].Cells[1].Text);
                        InsertToFileSource("0446",Name, Name2);
                        double totalAquirerSettlement = Convert.ToDouble(Name2);
        
                        Name = Convert.ToString(GridView1.Rows[13].Cells[0].Text);
                        Name2 = Convert.ToString(GridView1.Rows[13].Cells[1].Text);
                        InsertToFileSource("0446", Name, Name2);
                        double totalLoadSettlement = Convert.ToDouble(Name2);
        
                        InsertToNAV("21-01-041-00000 P/R - Clearing Account - Missing",Convert.ToString(totalAquirerSettlement+totalLoadSettlement));
        
                        Name = Convert.ToString(GridView1.Rows[18].Cells[0].Text);
                        Name2 = Convert.ToString(GridView1.Rows[18].Cells[1].Text);
                        InsertToFileSource("0446", Name, Name2);
                        InsertToNAV("21-01-044-00000 P/R - Clearing Account Write off",Name2);
        
                        Name = Convert.ToString(GridView1.Rows[26].Cells[0].Text);
                        Name2 = Convert.ToString(GridView1.Rows[26].Cells[3].Text);
                        InsertToFileSource("0446", Name, Name2);
                        InsertToNAV("21-01-031-00000 Issuerliab - CMgr", Name2);
        
                    }
                    if (FileUpload1.FileName.Contains("0501A") == true)
                    {
                        //calculateRNP();
                        InsertToNAV("21-01-032-00000 Issuerliab – Manual Adjustments", calculateRNP());
                    }
                    if (FileUpload1.FileName.Contains("Non-Rail") == true)
                    {
                        String merchant_Name = Convert.ToString(GridView1.Rows[9].Cells[5].Text);
                        String nonRail_Amount = Convert.ToString(GridView1.Rows[40].Cells[6].Text);
                        InsertToFileSource("SFF", merchant_Name, nonRail_Amount);
                        InsertToNAV(merchant_Name, nonRail_Amount);
                    }
                    if (FileUpload1.FileName.Contains("Rail") == true)
                    {
                        //String merchant_Name = Convert.ToString(GridView1.Rows[9].Cells[5].Text);
                        //String nonRail_Amount = Convert.ToString(GridView1.Rows[40].Cells[6].Text);
                    }
                }
            }
        
           protected void InsertToFileSource(String FileType,String Name, String Name2)
            {
                DataTable dt = (DataTable)ViewState["FileSource"];
                if(Name == "Total Acquirer Settlement"||Name == "Total Load Acquirer Settlement")
                    dt.Rows.Add(FileType, Name, Name2, "P/R - Clearing Account Missing ");
                if (Name == "Sub Total:")
                    dt.Rows.Add(FileType, Name, Name2, "P/R - Clearing Account WriteOff ");
                if(Name == "Net Total :")
                    dt.Rows.Add(FileType, Name, Name2, "Issuerliab - CMgr ");
                if (Name == "RNP")
                    dt.Rows.Add(FileType, Name, Name2, "Issuerliab – Manual Adjustments");
                else
                    dt.Rows.Add(FileType, Name, Name2, "SFF Non-Rail");
        
                this.BindGridView3();
            }
         protected void Page_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                DataTable dtGridView2 = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Document Source"),new DataColumn("Line Item Entry"), new DataColumn("Amount"), new DataColumn("NAV Account") });
                ViewState["FileSource"] = dt;
                this.BindGridView3();
        
                dtGridView2.Columns.AddRange(new DataColumn[3] { new DataColumn("Merchant Name"), new DataColumn("Debit"), new DataColumn("Credit") });
                ViewState["StatementOfAccounts"] = dtGridView2;
                this.BindGridView2();
        
        //there are new lines
                GridView1.DataSource = datasources;
                GridView1.DataBind();
            }
