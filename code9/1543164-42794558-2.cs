    // GET: Requests/CreateHistory
    public ActionResult CreateHistory(Status status)
    {
        History history = new History();
        history.Status = status;
        ViewBag.AvailableActions = _actionProvider.GetAvailableActions(User, Request, history);
        return View(history);
    }
