        /// <summary>
        /// If enabled by the define elsewhere, will dump the SQL from the main command of the report as a string
        /// Requires additional CR DLLs / usings from CR RAS SDK
        /// </summary>
        /// <param name="doc">A ReportDocument</param>
        private void DumpQueries(CrystalDecisions.CrystalReports.Engine.ReportDocument doc)
        {
            try
            {
                //CrystalDecisions.CrystalReports.Engine.ReportDocument boReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                CommandTable boCommandTable;
                var boReportClientDocument = doc.ReportClientDocument;
                var boDataDefController = boReportClientDocument.DataDefController;
                var boDatabase = boDataDefController.Database;
                //return; // disabled for now.
                //foreach (dynamic table in doc.ReportClientDocument.DatabaseController.Database.Tables)
                //{
                //    if (table.ClassName == "CrystalReports.CommandTable")
                //    {
                //        string commandSql = table.CommandText;
                //        Log?.DebugFormat(@"Report object: {0} - SQL: {1}", doc.Name, commandSql);
                //    }
                //}
                // revised based on  https://stackoverflow.com/questions/43208449/how-to-get-crystal-report-all-queries/57822774#57822774
                var sb = new StringBuilder();
                for (var i = 0; i < boDatabase.Tables.Count; i++)
                {
                    ISCRTable tableObject = boDatabase.Tables[i];
                    if (tableObject.ClassName == "CrystalReports.Table")
                    {
                        sb.AppendLine("Table " + i + ": " + tableObject.Name);
                    }
                    else
                    {
                        boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)boDatabase.Tables[i];
                        sb.AppendLine("Query " + i + ": " + boCommandTable.CommandText);
                    }
                }
                Log?.DebugFormat(@"Report object: {0} - SQL: {1}", doc.Name, sb.ToString());
                sb = new StringBuilder();
                foreach (string subName in boReportClientDocument.SubreportController.GetSubreportNames())
                {
                    SubreportClientDocument subRcd = boReportClientDocument.SubreportController.GetSubreport(subName);
                    for (var i = 0; i < boDatabase.Tables.Count; i++)
                    {
                        CrystalDecisions.ReportAppServer.DataDefModel.ISCRTable tableObject = boDatabase.Tables[i];
                        if (tableObject.ClassName == "CrystalReports.Table")
                        {
                            sb.AppendLine("Table " + i + ": " + tableObject.Name);
                        }
                        else
                        {
                            boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)subRcd.DatabaseController.Database.Tables[i];
                            sb.AppendLine(@"Subreport " + subName + @" - Query " + i + ": " + boCommandTable.CommandText);
                        }
                        //sql += Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Error(ex);
                throw;
            }
        }  
