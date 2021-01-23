        [HttpGet]
        [AjaxOnly]
        public ActionResult GetReportsInReviewGrid(int? page)
        {
            //Putting the totals model in Session is a hack, because grid.mvc.ajax will only upload the grid, not the panel.
            var items = GetReportInReviewViewModels();
            Session[STATUSPANELTOTALSINREVIEW] = GetStatusPanelTotalsViewModel(items); //(items); 
            return GetReportsGrid(items, GRIDREPORTSINREVIEW_PARTIAL_PATH);
        }
