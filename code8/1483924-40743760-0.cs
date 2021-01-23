     List<DAL.QuoteChartData> QuoteChartData = DAL.GetQuotesChart(SessionStore.Current.UserID, StartDate, EndDate);
            if (QuoteChartData.Count > 0)
            {
                //Populate Summary Chart
                chrtQuoteSummary.Legends.Add("Legend1");
                chrtQuoteSummary.Legends["Legend1"].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;
                chrtQuoteSummary.Series["Quotes"].IsValueShownAsLabel = true;
                chrtQuoteSummary.Series["Quotes"].Legend = "Legend1";
                chrtQuoteSummary.Series["Quotes"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
                QuoteChartData.ForEach(delegate (DAL.QuoteChartData R)
                {
                    chrtQuoteSummary.Series["Quotes"].Points.Add(new System.Web.UI.DataVisualization.Charting.DataPoint() { AxisLabel = R.QuoteStatus, YValues = new double[] { double.Parse(R.Tot.ToString()) } });
                    chrtQuoteSummary.Series["Quotes"].Points[chrtQuoteSummary.Series["Quotes"].Points.Count - 1].Color = Global.StatusColours[R.QuoteStatusID.ToString()];
                });
            }
            else
            {
                lblQuotesMsg.Text = "No quote data found for the current month.";
            }
