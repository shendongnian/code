    // First get the max id
    int auditId = context.Audits.Max(aa => aa.Id);
    // Now, pre-load the related entities
    context.Phases.Where(p => p.Audit.Id == auditId && p.Audit.EndDate == null).Load();
    context.UserActionLogs.Where(l => l.Phase.Audit.Id == auditId && l.Phase.Audit.EndDate == null).Load();
    // ... do the same for all related properties
    // And finally get the resulting object
    return context.Audits
            .Where(a => a.Id == auditId && a.EndDate == null)
            .SingleOrDefault();
