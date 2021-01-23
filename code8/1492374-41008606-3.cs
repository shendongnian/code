        public static DataTable ProcessMasterCodeCsvToDatatable(string file, int campaignId)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext()) {
                var campaign = _context.Campaigns.Find(campaignId);
                DataTable dt = new DataTable();
                dt.Columns.Add("CampaignId");
                dt.Columns.Add("Code");
                dt.Columns.Add("Used");
                dt.Columns.Add("SubmittedOn");
                string line = null;
                var submitDate = DateTime.Now;
                using (StreamReader sr = File.OpenText(file))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length > 0)
                        {
                            if (!string.IsNullOrEmpty(data[0]))
                            {
                                DataRow row = dt.NewRow();
                                row[0] = campaign.CampaignId;
                                row[1] = data[0];
                                row[2] = false;
                                row[3] = submitDate;
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                return dt;
            }
        }
        public static String ProcessMastercodeSqlBulkCopy(DataTable dt)
        {
            string Feedback = string.Empty;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cn.Open();
                using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                {
                    copy.ColumnMappings.Add(0, "CampaignId");
                    copy.ColumnMappings.Add(2, "Code");
                    copy.ColumnMappings.Add(3, "Used");
                    copy.ColumnMappings.Add(4, "SubmittedOn");
                    copy.DestinationTableName = "MasterCodes";
                    try
                    {
                        //Send it to the server
                        copy.WriteToServer(dt);
                        Feedback = "Master Code Upload completed successfully";
                    }
                    catch (Exception ex)
                    {
                        Feedback = ex.Message;
                    }
                }
            }
            return Feedback;
        }
