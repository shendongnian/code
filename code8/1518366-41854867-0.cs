    public class ChartTestController : Controller
        {
            /// <summary>
            /// Action method for main page.
            /// GET: /ChartTest/
            /// </summary>
            /// <param name="dataExists">It sets if chard should be displayed or "No data found text is displayed</param>
            /// <returns></returns>
            //
            public ActionResult Index(bool dataExists)
            {
                ChartViewModel model = null;
    
                if (dataExists)
                {
                    model = new ChartViewModel
                    {
                        Chart = GetChart()
                    };
                }
                else
                {
                    model = null;
                }
    
                return View(model);
            }
    
            /// <summary>
            /// it prepares Chart object
            /// </summary>
            /// <returns></returns>
            private Chart GetChart()
            {
                return new Chart(600, 400, ChartTheme.Blue)
                    .AddTitle("Number of website readers")
                    .AddLegend()
                    .AddSeries(
                        name: "WebSite",
                        chartType: "Pie",
                        xValue: new[] { "Digg", "DZone", "DotNetKicks", "StumbleUpon" },
                        yValues: new[] { "150000", "180000", "120000", "250000" });
    
            }
    
            /* usage: 
            * http://localhost:54087/ChartTest/GetChart?dateValue=10&regType=aaa&dataExists=false
            * http://localhost:54087/ChartTest/GetChart?dateValue=10&regType=aaa&dataExists=true
            */
            public ActionResult GetChart(long dateValue, string regType)
            {            
                var result = GetChart();
                result.Write("jpg");
                return null;
            }
        }
