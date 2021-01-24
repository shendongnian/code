    public ActionResult SolaceHistory()
        {
    var Criteria=DateTime.Now.AddDays(-14);
            var model = new SolaceHistoryList();
            model.Statuses = OnlineGivingContext.log_SolaceStatus.OrderByDescending(s => s.DateCreated.Date >= Criteria.Date).ToList();
            return View(model);
        }
