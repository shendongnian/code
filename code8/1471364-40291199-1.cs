        public ActionResult Results()
        {
            Date1 objdate1 = new Date1();
            objdate1.DateStart = DateTime.Now;
            Querys estview = new Querys();
            
            ViewBag.Metric = 1;
            ViewBag.Message = objdate1.DateStart.Value.ToString("yyyy-MMMM-dd");
            ViewBag.Title2 = "% of Electric Estimated";
            ViewBag.Descript = "Percentage of estimated electric bills per Month.";
            return View(estview.estimatedbills(objdate1.DateStart));
        }
        [HttpPost]
        public ActionResult Results(Date1 objdate1)
        {
            Querys estview = new Querys();
            ViewBag.Metric = 1;
            ViewBag.Message = objdate1.DateStart.Value.ToString("yyyy-MMMM-dd");
            ViewBag.Title2 = "% of Electric Estimated";
            ViewBag.Descript = "Percentage of estimated electric bills per Month.";
            return View(estview.estimatedbills(objdate1.DateStart));
        }
