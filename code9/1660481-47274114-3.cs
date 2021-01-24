    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[,] horas = new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 3, 1 }, { 4, 0 }, { 5, 1 }, { 6, 0 }, { 7, 0 }, { 8, 1 }, { 9, 1 } };
    
            var series1 = new Series
            {
                Color = Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.RangeColumn,
                CustomProperties = "PointWidth=0.8"
            };
    
            for (int i = 0; i < horas.GetLength(0); i++)
            {
                series1.Points.AddXY(horas[i, 0], horas[i, 1]);
            }
    
            Chart1.Series.Add(series1);
    
            Chart1.ChartAreas[0].AxisX.Interval = 1;
    
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 0, ToPosition = 1, Text = "0", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 1, ToPosition = 2, Text = "1", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 2, ToPosition = 3, Text = "2", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 3, ToPosition = 4, Text = "3", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 4, ToPosition = 5, Text = "4", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 5, ToPosition = 6, Text = "5", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 6, ToPosition = 7, Text = "6", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 7, ToPosition = 8, Text = "7", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 8, ToPosition = 9, Text = "8", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 9, ToPosition = 10, Text = "9", GridTicks = GridTickTypes.All });
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 10, ToPosition = 11, Text = "10", GridTicks = GridTickTypes.All });
        }
    }
