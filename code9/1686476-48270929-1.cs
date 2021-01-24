    _db.MerchApps
            .Where(ma => ma.User.Status != ApplicationStatus.Approved) 
            .GroupJoin(
                _db.MerchNoteHist,
                ma => ma.Id,
                noteList => note.AppId,
                (ma, noteList) => new 
                { 
                   MA = ma, 
                   Note = noteList.OrderByDescending(n=>n.CreatedDate).First()
                })
                //rest of your logic here
