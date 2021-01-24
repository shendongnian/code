     private byte[] GenerateLedgerCorePDF(GLReportSearchCriteria reportcriteria)
        {
            Document document = new Document(new Rectangle(842f, 595f), 25, 25, 60, 25);/*new Document(PageSize.A4, 25, 25, NewHeaderlogoHeight + 20f, 25);*/
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            writer.CloseStream = false;
            document.Open();
            Chapter ChapterforSection = new Chapter(new Paragraph("", _titleFont), i);
            ChapterforSection.NumberDepth = 0;
            Paragraph pp = new Paragraph("", _ColorFont);
            List<GLGeneralLedgerReport> result = null;
            if (reportcriteria.BalanceFrwd < reportcriteria.Period)
            {
                result = (from o in _repo.GLAccounts
                          join b in _repo.GLAccountTotals
                          on o.AccountID equals b.AccountID
                          where (o.Corporation.Equals(reportcriteria.Corporation)
                          && b.Year == reportcriteria.FiscalYear
                       && (b.Period > reportcriteria.BalanceFrwd && b.Period <= reportcriteria.Period))
                          select new GLGeneralLedgerReport
                          {
                              AccountNumber = o.AccountNumber,
                              AccountType = o.AccountType,
                              AccountDescription = o.AccountDescription,
                              AccountID = o.AccountID,
                              YTDBalance = b.YTDBalance,
                              ClassCode = o.ClassCode,
                              NormalBalance = o.NormalBalance,
                              NetChange = b.NetChange
                          }).OrderBy(b => b.AccountNumber).ToList();
            }
            else
            {
                result = (from o in _repo.GLAccounts
                          join b in _repo.GLAccountTotals
                          on o.AccountID equals b.AccountID
                          where (o.Corporation.Equals(reportcriteria.Corporation)
                          && b.Year == reportcriteria.FiscalYear
                       && (b.Period == reportcriteria.BalanceFrwd))
                          select new GLGeneralLedgerReport
                          {
                              AccountNumber = o.AccountNumber,
                              AccountType = o.AccountType,
                              AccountDescription = o.AccountDescription,
                              AccountID = o.AccountID,
                              YTDBalance = b.YTDBalance,
                              ClassCode = o.ClassCode,
                              NormalBalance = o.NormalBalance,
                              NetChange = b.NetChange
                          }).OrderBy(b => b.AccountNumber).ToList();
            }
            List<GLGeneralLedgerReport> resultOne = (from o in _repo.GLAccounts
                                                     join b in _repo.GLAccountTotals
                                                     on o.AccountID equals b.AccountID
                                                     where (o.Corporation.Equals(reportcriteria.Corporation)
                                                     && b.Year == reportcriteria.FiscalYear
                                                  && (b.Period == reportcriteria.Period))
                                                     select new GLGeneralLedgerReport
                                                     {
                                                         AccountNumber = o.AccountNumber,
                                                         AccountType = o.AccountType,
                                                         AccountDescription = o.AccountDescription,
                                                         AccountID = o.AccountID,
                                                         YTDBalance = b.YTDBalance,
                                                         ClassCode = o.ClassCode,
                                                         NormalBalance = o.NormalBalance,
                                                         NetChange = b.NetChange
                                                     }).OrderBy(b => b.AccountNumber).ToList();
            List<Guid?> AccountiDs = result.Select(s => s.AccountID).Distinct().ToList();
            PdfPTable headertable = ReportStyleHelper.GetTable(1);
            headertable.AddCell(ReportStyleHelper.GetChapterHeader(reportcriteria.Corporation, 7));
            headertable.AddCell(ReportStyleHelper.GetChapterHeader("General Ledger Report", 7));
            headertable.AddCell(ReportStyleHelper.GetChapterHeader("From 01/" + reportcriteria.FiscalYear + " To " + reportcriteria.Period + "/" + reportcriteria.FiscalYear, 7));
            pp.Add(headertable);
            foreach (Guid AccountiD in AccountiDs)
            {
                pp.Add(this.AddGenerateLedgerSection(AccountiD, reportcriteria));
            }
            PdfPTable tablelast = ReportStyleHelper.GetTable(3, new float[] { 2f, 1f, 1f });
            var aggregateResult = resultOne.GroupBy(x => x.AccountType).Select(
                 x => new
                 {
                     AccountType = x.Key,
                     NetChange = x.Sum(y => Convert.ToDecimal(y.NetChange)),
                     YTDBalance = x.Sum(y => y.YTDBalance),
                 }
                 ).ToList();
            var AELaggregateResult = aggregateResult.Where(a => a.AccountType == "Assets" || a.AccountType == "Equity" || a.AccountType == "Liabilities").ToList();
            var NOTAELaggregateResult = aggregateResult.Except(AELaggregateResult).ToList();
            tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Totals"));
            tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Current"));
            tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Year to Date "));
            foreach (var aggregate in AELaggregateResult)
            {
                tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Totals By " + aggregate.AccountType, PdfPCell.ALIGN_LEFT));
                tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(aggregate.NetChange))));
                tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(aggregate.YTDBalance))));
            }
            var AELprofitlossNetchange = aggregateResult.Where(a => a.AccountType == "Assets" || a.AccountType == "Equity" || a.AccountType == "Liabilities").Sum(a => a.NetChange);
            var AELprofitlossYTDBal = aggregateResult.Where(a => a.AccountType == "Assets" || a.AccountType == "Equity" || a.AccountType == "Liabilities").Sum(a => a.YTDBalance);
            tablelast.AddCell(ReportStyleHelper.GetEmptyCell(3));
            tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Profit or Loss"));
            tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(AELprofitlossNetchange))));
            tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(AELprofitlossYTDBal))));
            tablelast.AddCell(ReportStyleHelper.GetEmptyCell(3));
            foreach (var aggregate in NOTAELaggregateResult)
            {
                tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Totals By " + aggregate.AccountType, PdfPCell.ALIGN_LEFT));
                tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(aggregate.NetChange))));
                tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(aggregate.YTDBalance))));
            }
            var NotAELprofitlossNetchange = NOTAELaggregateResult.Sum(a => a.NetChange);
            var NotAELprofitlossYTDBal = NOTAELaggregateResult.Sum(a => a.YTDBalance);
            tablelast.AddCell(ReportStyleHelper.GetEmptyCell(3));
            tablelast.AddCell(ReportStyleHelper.GetSectionLabel("Profit or Loss"));
            tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(NotAELprofitlossNetchange))));
            tablelast.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(NotAELprofitlossYTDBal))));
            tablelast.AddCell(ReportStyleHelper.GetEmptyCell(3));
            pp.Add(tablelast);
            ChapterforSection.AddSection(pp, 0);
            document.Add(ChapterforSection);
            document.Close();
            return output.ToArray();
        }
     private PdfPTable AddGenerateLedgerSection(Guid AccountiD, GLReportSearchCriteria reportcriteria)
        {
            GLAccount result = _repo.GLAccounts.Where(b => b.AccountID == AccountiD).FirstOrDefault();
            int year = Convert.ToInt32(reportcriteria.FiscalYear);
            var resultGLAccountTotals = _repo.GLAccountTotals.Where(b => b.AccountID == AccountiD).ToList();
            decimal? YTDBalance = resultGLAccountTotals.Where(b => b.Period == reportcriteria.BalanceFrwd && b.Year == reportcriteria.FiscalYear).Select(x => x.YTDBalance).FirstOrDefault();
            PdfPTable table = ReportStyleHelper.GetTable(8, new float[] { 1f, 1f, 2.5f, 1f, 1f, 1f, 1f, 1f });
            table.AddCell(ReportStyleHelper.GetSectionLabel("Account", PdfPCell.ALIGN_LEFT));
            table.AddCell(ReportStyleHelper.GetSectionLabel(result.AccountNumber));
            table.AddCell(ReportStyleHelper.GetSectionLabel(result.AccountDescription));
            table.AddCell(ReportStyleHelper.GetSectionLabel("Balance frw ", PdfPCell.ALIGN_LEFT));
            table.AddCell(ReportStyleHelper.GetSectionLabel(Convert.ToString(reportcriteria.BalanceFrwd)));
            table.AddCell(ReportStyleHelper.GetSectionLabel(string.Format("{0:C}", Convert.ToDecimal(YTDBalance == null ? 0 : YTDBalance)), PdfPCell.ALIGN_RIGHT, 3));
            var resultGLAccountJournals = _repo.GLAccountJournals.Where(b => b.AccountID == AccountiD).OrderBy(b => b.JournalID).ToList();
            var filteredGLAccountJournals = resultGLAccountJournals.Where(a => a.PeriodReport > reportcriteria.BalanceFrwd && a.PeriodReport <= reportcriteria.Period && a.YearReport == year).ToList();
            var periodlist = filteredGLAccountJournals.Select(a => a.PeriodReport).Distinct().OrderBy(x => x.Value).ToList();
            decimal? NetChange = 0;
            decimal? LastYTDBalance = 0;
            if (filteredGLAccountJournals.Count > 0)
            {
                foreach (var item1 in periodlist)
                {
                    NetChange = resultGLAccountTotals.Where(b => b.Period == item1 && b.Year == reportcriteria.FiscalYear).Select(x => x.NetChange).FirstOrDefault();
                    LastYTDBalance = resultGLAccountTotals.Where(b => b.Period == item1 && b.Year == reportcriteria.FiscalYear).Select(x => x.YTDBalance).FirstOrDefault();
                    var filteredGLAccountJournals2 = filteredGLAccountJournals.Where(b => b.PeriodReport == item1).ToList();
                    table.AddCell(ReportStyleHelper.GetParagraphSeparater(8));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Period", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Journal Id", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("System", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Source Description", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Posting Date", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Debit", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Credit", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Balance", PdfPCell.ALIGN_RIGHT));
                    foreach (var item in filteredGLAccountJournals2)
                    {
                        table.AddCell(ReportStyleHelper.GetSectionText((item.PeriodReport).ToString()));
                        table.AddCell(ReportStyleHelper.GetSectionText(item.JournalID.ToString()));
                        table.AddCell(ReportStyleHelper.GetSectionText(item.SourceSystem));
                        table.AddCell(ReportStyleHelper.GetSectionText(item.SourceDescription));
                        table.AddCell(ReportStyleHelper.GetSectionText(item.PostDate.ToString("MM/dd/yyyy")));
                        table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(item.DebitAmount))));
                        table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(item.CreditAmount))));
                        table.AddCell(ReportStyleHelper.GetEmptyCell(1));
                    }
                    table.AddCell(ReportStyleHelper.GetEmptyCell(6));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Net change", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(Convert.ToDecimal(NetChange == null ? 0 : NetChange)))));
                    table.AddCell(ReportStyleHelper.GetEmptyCell(6));
                    table.AddCell(ReportStyleHelper.GetSectionLabel("Ending balance", PdfPCell.ALIGN_LEFT));
                    table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(Convert.ToDecimal(LastYTDBalance == null ? 0 : LastYTDBalance)))));
                    table.AddCell(ReportStyleHelper.GetParagraphSeparater(8));
                }
            }
            else
            {
                table.AddCell(ReportStyleHelper.GetEmptyCell(6));
                table.AddCell(ReportStyleHelper.GetSectionLabel("Net change", PdfPCell.ALIGN_LEFT));
                table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(Convert.ToDecimal(NetChange == null ? 0 : NetChange)))));
                table.AddCell(ReportStyleHelper.GetEmptyCell(6));
                table.AddCell(ReportStyleHelper.GetSectionLabel("Ending balance", PdfPCell.ALIGN_LEFT));
                table.AddCell(ReportStyleHelper.GetSectionText(string.Format("{0:C}", Convert.ToDecimal(Convert.ToDecimal(LastYTDBalance == null ? 0 : LastYTDBalance)))));
                table.AddCell(ReportStyleHelper.GetParagraphSeparater(8));
            }
            return table;
        }
