      private Total CreateTotal(Report report, DataBand dataBand, ReportSummaryBand repSumBand, ColumnHeader columnHeader)
        {
            // create total
            Total colTotal = new Total();
            colTotal.SetName("CountTotal");
            colTotal.Expression = "[MyTable.Count]";
            colTotal.Evaluator = dataBand;
            colTotal.PrintOn = repSumBand;
            colTotal.TotalType = TotalType.Sum;                  
            report.Dictionary.Totals.Add(colTotal);
            return colTotal;
        }
