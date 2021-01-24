    var customMail = this.db.Companies.Where(c => c.Id == company.Id)
        .Select(x => new { x.FromMail, x.FromName, x.Subject, x.EmailBody })
        .AsEnumerable() // Now you can use reflection
        .Where(
            a => a.GetType().GetProperties().All(pi => pi.GetValue(a) != null)
        );
