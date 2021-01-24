    public void Swap(InputObject input)
    {
        NamePriority prio = 
            context.NamePriorities
                .Where(w => w.Name == input.Name).FirstOrDefault();
        if (prio == null) return; // This was missing
        NamePriority prioToSwap = 
            context.NamePriorities
                .Where(w.Priority == input.Priority).FirstOrDefault();
        if (prioToSwap == null) return;  // This was missing
        prioToSwap.Priority = prio.Priority;
        prio.Priority = input.Priority;
        context.SaveChanges();
    }
