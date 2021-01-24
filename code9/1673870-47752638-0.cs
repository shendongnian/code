    IEnumerable<Payment> contactDateGroups = payments
       .GroupBy(x => new { x.ContactId, x.Date.Date })
       .Select(g => new Payment{ 
            ContactId = g.Key.ContactId,
            Date = g.Key.Date,
            Amount = g.Sum(x => x.Amount)
        });
