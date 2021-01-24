    void InitWithEvents(string persistenceId, params object[] events)
    {
        var probe = CreateTestProbe();
        var writerGuid = Guid.NewGuid().ToString();
        var writes = new AtomicWrite[events.Length];
        for (int i = 0; i < events.Length; i++)
        {
            var e = events[i];
            writes[i] = new AtomicWrite(new Persistent(e, i+1, persistenceId, "", false, ActorRefs.NoSender, writerGuid));
        }
        var journal = Persistence.Instance.Apply(Sys).JournalFor(null);
        journal.Tell(new WriteMessages(writes, probe.Ref, 1));
        
        probe.ExpectMsg<WriteMessagesSuccessful>();
        for (int i = 0; i < events.Length; i++)
            probe.ExpectMsg<WriteMessageSuccess>();
    }
