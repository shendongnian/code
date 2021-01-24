          private void DumpQueries(CrystalDecisions.CrystalReports.Engine.ReportDocument doc, string rptSourceName)
        {
            try
            {
                //CrystalDecisions.CrystalReports.Engine.ReportDocument boReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                CommandTable boCommandTable;
                var boReportClientDocument = doc.ReportClientDocument;
                var boDataDefController = boReportClientDocument.DataDefController;
                var boDatabase = boDataDefController.Database;
                var reportSummary = doc.SummaryInfo;
                var reportName = doc.Name ?? doc.FileName;
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
                sb.AppendLine();
                sb.AppendLine("---------- Summary -----------");
                sb.AppendLine($@"Report source: {rptSourceName}");
                sb.AppendLine($"Title: {reportSummary.ReportTitle}");
                sb.AppendLine($"Subject: {reportSummary.ReportSubject}");
                sb.AppendLine($"Comments: {reportSummary.ReportComments}");
                sb.AppendLine($"Author: {reportSummary.ReportAuthor}");
                sb.AppendLine($"Keywords: {reportSummary.KeywordsInReport}");
                sb.AppendLine($"Last Saved By: {reportSummary.LastSavedBy}");
                sb.AppendLine($"Revision #: {reportSummary.RevisionNumber}");
                sb.AppendLine("------------------------------");
                for (var i = 0; i < boDatabase.Tables.Count; i++)
                {
                    ISCRTable tableObject = boDatabase.Tables[i];
                    if (tableObject.ClassName == "CrystalReports.Table")
                    {
                        sb.AppendLine(@"Table " + i + ": " + tableObject.Name);
                    }
                    else
                    {
                        boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)boDatabase.Tables[i];
                        sb.AppendLine(@"Query " + i + ": " + boCommandTable.CommandText);
                    }
                }
                sb.AppendLine("------------------------------");
                sb.AppendLine("");
                sb.AppendLine("--------- Subreports ---------");
                foreach (string subName in boReportClientDocument.SubreportController.GetSubreportNames())
                {
                    SubreportClientDocument subRcd = boReportClientDocument.SubreportController.GetSubreport(subName);
                    sb.AppendLine($@"Subreport object: {subRcd.Name}");
                    sb.AppendLine("------------------------------");
                    for (var i = 0; i < boDatabase.Tables.Count; i++)
                    {
                        CrystalDecisions.ReportAppServer.DataDefModel.ISCRTable tableObject = boDatabase.Tables[i];
                        if (tableObject.ClassName == "CrystalReports.Table")
                        {
                            sb.AppendLine(@"Table " + i + ": " + tableObject.Name);
                        }
                        else
                        {
                            boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)subRcd.DatabaseController.Database.Tables[i];
                            sb.AppendLine(@"Query " + i + ": " + boCommandTable.CommandText);
                        }
                        //sql += Environment.NewLine;
                    }
                }
                Log?.Debug($@"Report contents: {  sb.ToString()}");
            }
            catch (Exception ex)
            {
                Log?.Error(ex);
                throw;
            }
        }
