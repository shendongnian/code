    var results = from q in query
        group q by new {q.SoldToContactID,FirstName=q.Contact.FirstName,LastName=q.Contact.LastName} into g
        select new LeadBuyersByStateItem {
            ContactID = g.Key.SoldToContactID,
            FirstName = g.Key.FirstName,
            LastName = g.Key.LastName
            ContactCount = g.Count()
         };
