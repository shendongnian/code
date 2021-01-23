    var auditObject = context.Audits.Where(a => a.Id == context.Audits.Max(aa => aa.Id) && a.EndDate == null)
            .Include(a => a.Phases.Select(p => p.UserActionLogs))
            .Include(a => a.Phases.Select(p => p.Reminders))
            .FirstOrDefault();
    
    
    auditObject = context.Audits.Where(a => a.Id == context.Audits.Max(aa => aa.Id) && a.EndDate == null)
            .Include(a => a.Phases.Select(p => p.PhaseType))
            .Include(a => a.AuditResources.Select(ar => ar.Resource))
            .FirstOrDefault();
    
    auditObject = context.Audits.Where(a => a.Id == context.Audits.Max(aa => aa.Id) && a.EndDate == null)
            .Include(a => a.AuditCostCenterManagers.Select(acm => acm.CostCenterManager))
            .Include(a => a.AuditResources.Select(ar => ar.ResourceOwners.Select(ro => ro.Owner)))
            .FirstOrDefault();
    
    auditObject = context.Audits.Where(a => a.Id == context.Audits.Max(aa => aa.Id) && a.EndDate == null)
              .Include(a => a.AuditResources.Select(ar => ar.UserFiles.Select(uf => uf.UserLists)))
              .Include(a => a.AuditType)
              .FirstOrDefault();
    
    return  auditObject;
