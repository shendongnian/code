    var accounts = db.Accounts.AsQueryable();
    if (accountIds != null && accountIds.Count > 0)
    {
        accounts = accounts.Where(a => accountIds.Contains(a.AccountID));
    }
    
    var query = (from i in db.Incidents
                 join s in db.Sites on i.SiteID equals s.SiteID
                 join a in accounts on i.AccountID equals a.AccountID
                 join st in db.Status on i.StatusID equals st.StatusID
                 join currentUser in db.Users on i.CurrentAssignedUser equals currentUser.UserID
                 join loggedByUser in db.Users on i.LoggedByUser equals loggedByUser.UserID
                 join createdByUser in db.Users on i.CreatedByUser equals createdByUser.UserID
                 join l in db.Locations on i.Location equals l.LocationID into locList
                 from loc in locList.DefaultIfEmpty()
                 join q in db.QuestionCategories on i.QuestionCategoryID equals q.QuestionCategoryID
                 join ia in db.IncidentActions on i.IncidentID equals ia.IncidentID into iaList
                 from actions in iaList.DefaultIfEmpty()
    
                
                 select new
                 {
                     Title = i.Title,
                     IncidentID = i.IncidentID,
                     StatusName = st.StatusName,
                     StatusID = i.StatusID,
                     ReferenceNumber = i.ReferenceNo,
                     AccountName = a.AccountName,
                     AccountID = i.AccountID,
                     SiteName = s.SiteName,
                     SiteID = i.SiteID,
                     LocationName = loc.LocationName,
                     LocationID = i.Location,
                     CatName = q.QuestionCategoryName,
                     CatID = i.QuestionCategoryID,
                     CurrentAssignedUser = currentUser.FirstName + " " + currentUser.LastName,
                     AssignedUserID = i.CurrentAssignedUser,
                     CreatedByUser = createdByUser.FirstName + " " + createdByUser.LastName,
                     DateCreated = i.LoggedDate,
                     DepartmentID = i.DepartmentID,
                     Logger = loggedByUser.FirstName + " " + loggedByUser.LastName,
                     LoggedBy = i.LoggedByUser,
                     EscalationCount = i.EscalationCount)
                 });
