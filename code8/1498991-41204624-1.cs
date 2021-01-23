        private const string connectionString = 
        ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void btnAffRntGoClick(object sender, EventArgs e)
        {
            var from = new DateTime(1900, 1, 1);
            var to = new DateTime(2100, 1, 1);
            var validStartDate = !DateTime.TryParse(txtStartDate.Text, out from);
            var validEndDate = !DateTime.TryParse(txtEndDate.Text, out to);
            
            var hasValidDates = validStartDate && validEndDate;
            var hasDifference = DateTime.Compare(from, to) > 0;
            if (!hasValidDates || !hasDifference)
            {
                pnlStatus.Visible = true;
                lblPageStatus.Text = "Please Check the Dates";
            }
            else
            {
                DataSet ds = SqlHelper.ExecuteDataset(connectionString,
                        "SPNAME",
                        Convert.ToInt64(ddl.SelectedValue), dtFrom.Date.ToShortDateString(),
                        dtTo.Date.ToShortDateString(), ddl2.SelectedValue, Chk1.Checked);
                var hasData = ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
                pnlStatus.Visible = !hasData;
                lblPageStatus.Text = hasData ? string.Empty : "No data available to export.";
            }
        }
