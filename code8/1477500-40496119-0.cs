    [HttpPost]
    public ActionResult Create([Bind(Include="ID, comments")] ticketComment)
    {
        if (ModelState.IsValid)
        {
            ...
            return RedirectToAction("Details", "Ticket", new { Id = ticket.ID });
        }
        return View(ticketComment);
    }
