            db.MyManagers.Remove(db.MyManagers
                           .FirstOrDefault(e => e.ProjectId == projectId 
                              && e.MyManagerId == Id));
            var newCurrentManager = db.MyManagers
                           .ToList()
                           .Where(e => e.ProjectId == projectId 
                            && db.Entry(e).State != EntityState.Deleted)//This will query the entity traker 
                           .OrderByDescending(i => i.FromDate)
                           .FirstOrDefault();
            newCurrentManager.TillDate = null;
            newCurrentManager.IsCurrentManager = true;
            db.SaveChanges();
