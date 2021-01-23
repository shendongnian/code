        private const string connectionString = 
        ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void btnAffRntGoClick(object sender, EventArgs e)
        {
            var from = new DateTime(1900, 1, 1);
            var to = new DateTime(2100, 1, 1);
            var isValidStartDate = !DateTime.TryParse(txtStartDate.Text, out from);
            var isValidEndDate = !DateTime.TryParse(txtEndDate.Text, out to);
            var hasValidDates = isValidStartDate && isValidEndDate;
            var hasDifference = DateTime.Compare(from, to) > 0;
            var shouldCheckDates = !hasValidDates || !hasDifference;
            if (shouldCheckDates)
            {
                pnlStatus.Visible = true;
                lblPageStatus.Text = "Please Check the Dates";
                return;
            }
            DataSet ds = SqlHelper.ExecuteDataset(connectionString,
                "SPNAME",
                Convert.ToInt64(ddl.SelectedValue)
                , @from.Date.ToShortDateString(),
                to.Date.ToShortDateString()
                , ddl2.SelectedValue
                , Chk1.Checked
            );
            var hasData = ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
            pnlStatus.Visible = !hasData;
            lblPageStatus.Text = hasData ? string.Empty : "No data available to export.";
        }
