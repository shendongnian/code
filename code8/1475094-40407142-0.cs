    const string ticketSentKey = "ticketSent";
    public ActionResult Index()
    {
        var ticketSent = false;
        if(TempData.ContainsKey(ticketSentKey)) 
            ticketSebt = bool.Parse(TempData[ticketSentKey]);
        if (ticketSent == true)
            ViewBag.IfcText = "done";
        else
            ViewBag.IfcText = "hello";
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "TicketNumber,OwnerName,Email,LaptopModelNumber,Subject,Description,ComplainDate")] Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
            TempData[ticketSentKey] = true;
            return RedirectToAction("Index");
        }
        return View(ticket);
    }
