    var changeViewModels = from change in db.Changes
                           let lastChangeHistory = change.ChangeHistory.Max(changeHistory => changeHistory.Date)
                           let firstChangeHistory = change.ChangeHistory.Min(changeHistory => changeHistory.Date)
                           select new ChangeViewModel
                           {
                               ID = change.ID,
                               Title = change.Title,
                               Description = change.Description,
                               InitiationDate = firstChangeHistory.Date,
                               StatusDate = lastChangeHistory.Date,
                               CurrentStatus = lastChangeHistory.Status,
                           }.ToList();
