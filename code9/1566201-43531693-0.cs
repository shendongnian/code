    var timeEntries = context.TimeEntries.Where(t => timeEntryIds.Contains(te.Id)).ToArray();
    
    foreach(var timeEntry in timeEntries)
        invoice.TimeEntries.Add(timeEntry);
    
    context.Invoices.Add(invoice);
    
    //save the entire context and takes care of the ids
    context.SaveChanges();
