            var startDate = date.Date;
            var endDate = date.Date.AddDays(1);
            return db.Events
            .Where(e =>
                e.BedId == bed
                && e.Date >= startDate
                && e.Date < endDate)
            .Select(x => new EventViewModel()
            {
                Id = x.Id,
                Date = x.Date,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Planned = x.Planned,
                EngineSN = x.EngineSN,
                Details = x.Details,
                Bed = x.Bed.Name,
                Category = x.Subcategory.Category.Name,
                Subcategory = x.Subcategory.Name,
                Project = x.Project.Name,
                Type = x.Type.ToString()
            })
            .ToList();
