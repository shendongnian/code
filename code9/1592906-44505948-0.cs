         {
            var Criteria = DateTime.Today.AddDays(-14);
            var model = new SolaceHistoryList();
            model.Statuses = OnlineGivingContext.log_SolaceStatus
                .Where(st => st.DateCreated >= Criteria).
                OrderByDescending(s => s.DateCreated).ToList();
            return View(model);
        }
