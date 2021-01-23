    var changeViewModels = (from change in db.Changes
                            let lastChangeHistory = change.ChangeHistory.OrderBy(changeHistory => changeHistory.Date).Last()
                            let firstChangeHistory = change.ChangeHistory.OrderBy(changeHistory => changeHistory.Date).First()
                            select new ChangeViewModel
                            {
                                ID = change.ID,
                                Title = change.Title,
                                Description = change.Description,
                                InitiationDate = firstChangeHistory.Date,
                                StatusDate = lastChangeHistory.Date,
                                CurrentStatus = lastChangeHistory.Status,
                            }).ToList();
