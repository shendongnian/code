        protected void btnImport_ServerClick(object sender, EventArgs e)
        {
            HasUpload = true;
            for(int z = 1000;z < 3322;z++)
            {
                double overallPercentageFull = Math.Round((z * 100.0) / 3322, 1);
                Lbl_PercentageCheck.InnerText = overallPercentageFull.ToString() + "%";
                ProgressBarDiv.Style.Add("width", (overallPercentageFull).ToString() + "%");
                ProgressBarDiv.Attributes.Add("aria-valuenow", overallPercentageFull.ToString());
                if (overallPercentageFull < 15.0)
                {
                    Lbl_PercentageCheck.Style.Add("ForeColor", "green");
                }
                else if (overallPercentageFull >= 15.0)
                {
                    Lbl_PercentageCheck.Style.Add("ForeColor", "red");
                }
                Thread.Sleep(2000);
                Lbl_PercentageCheck.InnerText = overallPercentageFull.ToString() + "%";
                ProgressBarDiv.Style.Add("width", (overallPercentageFull).ToString() + "%");
                ProgressBarDiv.Attributes.Add("aria-valuenow", overallPercentageFull.ToString());
                if (overallPercentageFull < 15.0)
                {
                    Lbl_PercentageCheck.Style.Add("ForeColor", "green");
                }
                else if (overallPercentageFull >= 15.0)
                {
                    Lbl_PercentageCheck.Style.Add("ForeColor", "red");
                }
            }
