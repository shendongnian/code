    public ActionResult Message(String someVariable)
        {
            //do something with the contents of someVariable
            chartstype chartname = new chartstype();
            List<chartstype> listchart = new List<chartstype>();
            chartname.charttype = "Column";
            listchart.Add(chartname);
            TempData["name"] =listchart;
            TempData.Keep();
            return View();
        }
