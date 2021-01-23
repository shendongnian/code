        [HttpGet]
        [AjaxOnly]
        public PartialViewResult GetStatusPanelTotalsInReview()
        {
            var model = Session[STATUSPANELTOTALSINREVIEW];
            return PartialView("Partials/_StatusPanelTotals", model);
        }
