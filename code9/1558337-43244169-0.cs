    var espToProcess = db.RootDomainEmailSeriesProgresses;
    foreach (var esp in espToProcess)
    {
        bool carryOn = esp.MoveNext(db);
        db.SaveChanges();   //Exception
        if (!carryOn) continue; 
        //--> rest of my code
    }
    public bool MoveNext(DbContext db)
    {
        if (this.CompletedTargets == null) this.CompletedTargets = new 
    List<EmailAddress>();
        if (this.CurrentTarget != null)
        {
            this.CompletedTargets.Add(this.CurrentTarget);
            this.CurrentTarget = null;
        }
        this.CurrentProgress = "";
        if (this.RootDomain.ContactFilter != RootDomain.ContactFilterType.None)
        {
            this.Status = EmailSeriesStatus.Aborted;
            return false;
        }
        var allTargets = 
    RootDomainEmailManager.SortDomainsEmailsByDesirability(this.RootDomain.ID);
        var toDo = allTargets.Except(this.CompletedTargets);
        if (toDo.Count() < 1)
        {
            this.Status = EmailSeriesStatus.Completed;
            return false;
        }
        List<string> targetEmailList = allTargets.Select(e => e.Email).ToList();
        List<EmailFilter> emailFilters = this.GetFilters(allTargets, db);
        if (emailFilters.Any(x => x.Filter == EmailFilterType.Unsubscribe || 
    x.Filter == EmailFilterType.Responded || x.Filter == 
    EmailFilterType.ManualContactOnly))
        {
            this.Status = EmailSeriesStatus.Aborted;
            if (this.RootDomain.ContactFilter == 0) 
    this.RootDomain.ContactFilter = 
    RootDomain.ContactFilterType.HasAssociatedEmailFilter;
            return false;
        }
        this.CurrentTarget = toDo.First();
        return true;
    }
    private List<EmailFilter> GetFilters(List<EmailAddress> allTargets, DbContext db)
    {
        db.Configuration.AutoDetectChangesEnabled = false;
        db.Configuration.LazyLoadingEnabled = false;
        var targetEmailList = allTargets.Select(e => e.Email).ToList();
        return db.EmailFilters.AsNoTracking().Where(x => 
    targetEmailList.Contains(x.Email)).ToList();
   }
