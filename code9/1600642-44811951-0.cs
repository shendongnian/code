    ReceivedMessage record = db.ReceivedMessages.FirstOrDefault(p => p.PatientId == status.PatientId &&
                                                                        p.DialogId == status.ConversationId);
    //  Add new if not exists
    bool newRecord = false;
    if (record == null)
    {
        record = new ReceivedMessage();
        record.Id = Guid.NewGuid();
        newRecord = true;
    }
    // Save fields
    // ...
    // Save to DB
    if (newRecord)  // Workaround for EF 6.1 bug: https://stackoverflow.com/a/44811951/630169
        db.ReceivedMessages.Add(record);
    else
        db.Entry(record).CurrentValues.SetValues(record);
    db.SaveChanges();
