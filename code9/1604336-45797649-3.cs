    public string AddEventRegistration(EventReg eventReg)
    {
        this.database.GetCollection<EventReg>("event_regs").InsertOne(eventReg);
        return eventReg.EventRegId;
    }
