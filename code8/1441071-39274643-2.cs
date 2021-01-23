    var jointData = (from d in db.DomainData
                     join s in db.SystemUrls on d.Id equals s.DomainId into sg
                     new { m.DomainName, m.OrgId, DomainId = m.Id, s.TypeId }).ToList();
    
    var result = jointData.GroupBy(item => new { item.DomainName, item.OrgId, item.DomainId })
                 .Select(g => new { 
                     g.Key.DomainName, 
                     g.Key.OrgId, 
                     g.Key.DomainId, 
                     TypeId = string.Join(", ", g.Select(item => item.TypeId))
                 });
