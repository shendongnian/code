    var micrositeResponseAdor = (
        from p in _context.MicrositeResponseAdor
        join c in _context.UserTracking on p.Id equals c.UserTrackingId into pc
        select new {
            MicrositeResponseAdor = p,
            UserTracking = pc 
        }
    ).FirstOrDefault();
