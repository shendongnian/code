    var changeViewModels = from change in db.Changes
                           from lastChangeHistory in change.ChangeHistory.Max(changeHistory => changeHistory.Date)
                           from firstChangeHistory in change.ChangeHistory.Min(changeHistory => changeHistory.Date)
                           select new ChangeViewModel
                           {
                               ID = change.ID,
                               Title = change.Title,
                               Description = change.Description,
                               InitiationDate = firstChangeHistory.Date,
                               StatusDate = lastChangeHistory.Date,
                               CurrentStatus = lastChangeHistory.Status,
                           }.ToList();
