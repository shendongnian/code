    private void LoadData()
    {
        List<double> allValues = new List<double>();
        if (CON.State == ConnectionState.Open)
        {
            CON.Close();
        }
        CON.ConnectionString = ConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
        CON.Open();
        CMD = new SqlCommand("select * from tblWeeklyAudit", CON);
        RDR = CMD.ExecuteReader();
        while (RDR.Read())
        {
            allValues.Add(Convert.ToDouble(RDR["Defects"]));
        }
        SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values = new ChartValues<double>(allValues)
                    }
                };
        Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
        DataContext = this;
    }
