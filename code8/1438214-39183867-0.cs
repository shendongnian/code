    var newDate = DateTime.Now.Date.AddDays(-30);
     var deliverableItems = db.Deliverables
     .ToList() // fetch all records from Deliverable table.
    .Where(d => d.DeliverableDueDate.Year == newDate.Year &&
    d.DeliverableDueDate.Month == newDate.Month&&
    d.DeliverableDueDate.Day == newDate.Day  );
