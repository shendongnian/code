        namespace reBase.Controllers
    {
        public class contactsClassesController : Controller
        {
            private dataEntityModel db = new dataEntityModel();
    
            // GET: contactsClasses
            public ActionResult Index()
            {
                var contactClasses = db.contactClasses.Include(c => c.empStatusClass).Include(c => c.regionsClass);
                return View(contactClasses.ToList());
            }
    
            // GET: contactsClasses/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                contactsClass contactsClass = db.contactClasses.Find(id);
                if (contactsClass == null)
                {
                    return HttpNotFound();
                }
                return View(contactsClass);
            }
    
            // GET: contactsClasses/Create
            public ActionResult Create()
            {
                ViewBag.TeamID = new SelectList(db.ticketClasses, "ticketID", "ticketName");
                var contact = new contactsClass();
                contact.tickets = new List<ticketsClass>();
                populateAssignedTicketData(contact);
                ViewBag.empStatusID = new SelectList(db.empStatClasses, "empStatusID", "employmentStatus");
                ViewBag.regionID = new SelectList(db.regionClasses, "regionID", "regionName");
                return View();
            }
    
            // POST: contactsClasses/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ID,FirstName,LastName,MobNo,LandLine,EmailAddress,HourlyRate,empStatusID,regionID,isOnSite")] contactsClass contactsClass)
            {
                if (ModelState.IsValid)
                {
                    db.contactClasses.Add(contactsClass);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
    
                ViewBag.empStatusID = new SelectList(db.empStatClasses, "empStatusID", "employmentStatus", contactsClass.empStatusID);
                ViewBag.regionID = new SelectList(db.regionClasses, "regionID", "regionName", contactsClass.regionID);
                populateAssignedTicketData(contactsClass);
                return View(contactsClass);
            }
    
            // GET: contactsClasses/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //contactsClass contactsClass = db.contactClasses.Find(id);
                contactsClass contactsClass = db.contactClasses
                              .Include(p => p.tickets)
                              .Where(i => i.ID == id)
                              .Single();
    
                if (contactsClass == null)
                {
                    return HttpNotFound();
                }
                ViewBag.empStatusID = new SelectList(db.empStatClasses, "empStatusID", "employmentStatus", contactsClass.empStatusID);
                ViewBag.regionID = new SelectList(db.regionClasses, "regionID", "regionName", contactsClass.regionID);
                populateAssignedTicketData(contactsClass);
                return View(contactsClass);
            }
            private void populateAssignedTicketData(contactsClass contactsClass)
            {
                var allTickets = db.ticketClasses;
                var contactTicket = new HashSet<int>(contactsClass.tickets.Select(b => b.ticketID));
                var viewModelAvailable = new List<contactTicketVM>();
                var viewModelSelected = new List<contactTicketVM>();
                foreach (var ticket in allTickets)
                {
                    if (contactTicket.Contains(ticket.ticketID))
                    {
                        viewModelSelected.Add(new contactTicketVM
                        {
                            ticketID = ticket.ticketID,
                            ticketName = ticket.ticketName,
                            //Assigned = true
                        });
                    }
                    else
                    {
                        viewModelAvailable.Add(new contactTicketVM
                        {
                            ticketID = ticket.ticketID,
                            ticketName = ticket.ticketName,
                            //Assigned = false
                        });
                    }
                }
    
                ViewBag.selOpts = new MultiSelectList(viewModelSelected, "ticketID", "ticketName");
                ViewBag.availOpts = new MultiSelectList(viewModelAvailable, "ticketID", "ticketName");
            }
    
            // POST: contactsClasses/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int? id, [Bind(Include = "ID,FirstName,LastName,MobNo,LandLine,EmailAddress,HourlyRate,empStatusID,regionID,isOnSite")] contactsClass contactsClass, string[] selectedOptions)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(contactsClass).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                var contactToUpdate = db.contactClasses
        .Include(p => p.tickets)
        .Where(i => i.ID == id)
        .Single();
                if (TryUpdateModel(contactToUpdate, "",
                       new string[] { "ID", "FirstName", "LastName", "MobNo", "LandLine", "EmailAddress", "HourlyRate", "isOnSite", "empStatusID", "regionID" }))
                {
                    try
                    {
                        updateContactTickets(selectedOptions, contactToUpdate);
    
                        db.Entry(contactToUpdate).State = EntityState.Modified;
                        db.SaveChanges();
    
                        return RedirectToAction("Index");
                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
    
    
                ViewBag.empStatusID = new SelectList(db.empStatClasses, "empStatusID", "employmentStatus", contactsClass.empStatusID);
                ViewBag.regionID = new SelectList(db.regionClasses, "regionID", "regionName", contactsClass.regionID);
                populateAssignedTicketData(contactToUpdate);
                return View(contactToUpdate);
            }
            private void updateContactTickets(string[] selectedOptions, contactsClass contactToUpdate)
            {
                if (selectedOptions == null)
                {
                    contactToUpdate.tickets = new List<ticketsClass>();
                    return;
                }
    
                var selectedOptionsHS = new HashSet<string>(selectedOptions);
                var contactTickets = new HashSet<int>
                    (contactToUpdate.tickets.Select(b => b.ticketID));
                foreach (var ticket in db.ticketClasses)
                {
                    if (selectedOptionsHS.Contains(ticket.ticketID.ToString()))
                    {
                        if (!contactTickets.Contains(ticket.ticketID))
                        {
                            contactToUpdate.tickets.Add(ticket);
                        }
                    }
                    else
                    {
                        if (contactTickets.Contains(ticket.ticketID))
                        {
                            contactToUpdate.tickets.Remove(ticket);
                        }
                    }
                }
            }
    
            // GET: contactsClasses/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                contactsClass contactsClass = db.contactClasses.Find(id);
                if (contactsClass == null)
                {
                    return HttpNotFound();
                }
                return View(contactsClass);
            }
    
            // POST: contactsClasses/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                contactsClass contactsClass = db.contactClasses.Find(id);
                db.contactClasses.Remove(contactsClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
