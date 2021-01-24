    var events = this.db.Events
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.IsPublic)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartDateTime = e.StartDateTime,
                    Duration = e.Duration,
                    Author= e.Author.FullName,
                    Location = e.Location
                });
