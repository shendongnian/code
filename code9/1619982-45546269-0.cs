    [HttpPost]
    public ActionResult CreateEvent(CreateEventViewModelSomething model)
    {
        // some event reservation/persistent logic
        var newlyReservedEventId = _calendarService.CreatePendingReservation();
        return return RedirectToAction("EditEvent", new { id = newlyReservedEventId });
    }
    public ActionResult EditEvent(int id)
    {
        var model = new CalendarEventEditModel();
        model.PendingReservationId = id;
        return View(model);
    }
