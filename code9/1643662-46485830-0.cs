    public ActionResult Index() 
            {
                ViewBag.Status = new[] { "A", "B" };
    
                return View();
            }
    //This controller returns an jpeg image you can use bmp but I think this will be better.
            public ActionResult Chart(string status) 
            {
                WebImage image;
                switch (status)
                {
                    case "A":
                        image = new Chart(width: 800, height: 400, theme: ChartTheme.Blue)
                        .AddTitle("Chart")
                        .AddSeries("Default", chartType: "Column", xValue: new[] { "A" }, yValues: new[] { 10 })
                        .ToWebImage("jpeg");
                        break;
                    default:
                        image = new Chart(width: 800, height: 400, theme: ChartTheme.Blue)
                        .AddTitle("Chart")
                        .AddSeries("Default", chartType: "Column", xValue: new[] { "B" }, yValues: new[] { 20 })
                        .ToWebImage("jpeg");
                        break;
                }
    
                return File(image.GetBytes(), "image/jpeg");
    
            }
