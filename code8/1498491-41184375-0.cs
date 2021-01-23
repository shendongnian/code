    var clients = db.ClientsTbls
            .Select(s => new
                {
                Text = s.Name + "-" + s.City,
                Value = s.clientId
            })
            .ToList();
        
    ViewBag.clientsList= new SelectList(clients, "Value", "Text");
