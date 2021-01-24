    public ActionResult LengthOfService()
            {
                ViewBag.Title = "Length of Service Awards Report";
                var people = db.People.ToList().Where(p => !p.EndDate.HasValue);
                var now = DateTime.Today;
                var period = 5;
                var maxPeriod = 30;
                var query = (from p in people
                            let interval = DateTime.MinValue.AddDays((now - p.LengthOfService).TotalDays).Year / period
                            where interval > 0
                            group p by Math.Min(interval * period, maxPeriod) into x
                            orderby x.Key
                            select new AwardInfo
                            {
                                Years = x.Key,
                                People = x
                            }).ToList(); 
                return View(query);
            }
