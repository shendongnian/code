            public ActionResult Message(String chartName)
            {
                chartstype chartname = new chartstype();
                List<chartstype> listchart = new List<chartstype>();
                chartname.charttype = chartName;
                listchart.Add(chartname);
                TempData["name"] =listchart;
                TempData.Keep();
                return View();
            }
