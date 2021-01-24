    public void Swap(InputObject input)
    {
        NamePriority prio = 
            context.NamePriorities
                .Where(w => w.Name == input.Name).FirstOrDefault();
        NamePriority prioToSwap = 
            context.NamePriorities
                .Where(w.Priority == input.Priority).FirstOrDefault();
        prioToSwap.Priority = prio.Priority;
        prio.Priority = input.Priority;
        context.SaveChanges();
    }
