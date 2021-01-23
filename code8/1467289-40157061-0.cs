    var ChangeWithStatus = from change in db.Changes
                           from lastHistoryChange in change.ChangeHistory.Max(changeHistory => changeHistory.Date)
                           from firstHistoryChange in change.ChangeHistory.Min(changeHistory => changeHistory.Date)
                           select new ChangeViewModel
                           {
                               ID = change.ID,
                               Title = change.Title,
                               Description = change.Description,
                               InitiationDate = firstHistoryChange.Date,
                               StatusDate = lastHistoryChange.Date,
                               CurrentStatus = lastHistoryChange.Status,
                           };
