    var alerts = db.Alerts.Where(a=>a.alertType.Slug== alert && a.EndDate>=DateTime.Now && a.Published=="Yes").Select(s=>new
            { 
                Title = s.Title, 
                Description = s.Description, 
                AlertType = s.alertType.Slug, 
                StartDate = s.StartDate, 
                EndDate = s.EndDate, 
                Location = s.Location.Select(l => new Location { l.Name, l.Latitude, l.Longitude, l.ParkId, l.Contact })
            });
