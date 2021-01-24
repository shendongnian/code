        protected void Page_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Your SQL here.", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable ChartData = ds.Tables[0];
            Chart1.Series[0].Points.DataBind(ChartData.DefaultView, "Teacher_code", "avgmarks", "");
            for (int i = 0; i < Chart1.Series[0].Points.Count; i++)
                Chart1.Series[0].Points[i].Label = string.Format("{0:0.00} ({1})", ChartData.Rows[i]["avgmarks"], ChartData.Rows[i]["no_of_copies"]);
            connection.Close();
        }
