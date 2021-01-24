    using LinqKit;
    
    using (MyDbContext db = new MyDbContext()) {
        var codeTableValueSelector = GetCodeTableValueSelectorExpression(2); 
        return db.Notifications.AsExpandable()
            .Where(x => x.id = 1)        
            .Select(x => new NotificationPOCO
            {
                Id = x.Id,
                Message = x.Message,
                Type = codeTableValueSelector.Invoke(x) // or x.CodeTable? not sure from the sample code
            })
            .ToList();
    }
