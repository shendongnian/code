    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new MyDataTable();
            //first add your series
            foreach (DataRow row in dt.DefaultView.ToTable(true, new string[] { "Type" }).Rows)
            {
                Series series = new Series();
                series.Name = (string)row["Type"];
                series.ChartType = SeriesChartType.StackedColumn;
                Chart1.Series.Add(series);
            }
            // then add your points;
            foreach (DataRow row in dt.Rows)
                Chart1.Series[(string)row["Type"]].Points.AddXY(row["Location"], new object[] { row["Total"] });
        }
    }
