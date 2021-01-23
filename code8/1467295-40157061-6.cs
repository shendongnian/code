    var changeViewModels = (from change in db.Changes
                            let lastChangeHistory = change.ChangeHistory.OrderByDescending(changeHistory => changeHistory.Date).FirstOrDefault()
                            let firstChangeHistory = change.ChangeHistory.OrderBy(changeHistory => changeHistory.Date).FirstOrDefault()
                            select new ChangeViewModel
                            {
                                ID = change.ID,
                                Title = change.Title,
                                Description = change.Description,
                                InitiationDate = firstChangeHistory.Date,
                                StatusDate = lastChangeHistory.Date,
                                CurrentStatus = lastChangeHistory.Status,
                            }).ToList();
