    namespace WebApplication1
    {
        public partial class WebFormChart : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                
                
    
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                       .AddTitle("Title")
                       .AddSeries(chartType: "pie",
                           xValue: new[] { "name1", "name2", "name3", "name4", "name5" },
                           yValues: new[] { "4", "6", "4", "5", "7" });
                myChart.ToWebImage().Save(@"Chart\chart", "jpeg", true);
                Image1.ImageUrl = @"Chart\chart.jpeg";
                
            }
    
        }
    }
