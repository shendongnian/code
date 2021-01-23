        IEnumerable<Whatever> query = SList; // avoid var here, as will impact later assignment
        if (!string.IsNullOrEmpty(txbbox.Text)) 
        {
            var when = DateTime.Parse(txbbox.Text); // to avoid parsing per item
            query = query.Where(s => s.date == when);
        }
        if (!string.IsNullOrEmpty(txbbox.Text))
        {
            query = query.Where(s => s.type.Contains(txbbox.Text));
        }
        Stemp = query.OrderBy(s => s.DateScadenze).ToList();
