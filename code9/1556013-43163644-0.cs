    var regPoints = (from x in db.CertPoints
                                     join y in db.CommunityPts on x.PointId equals y.PointId into z
                                     join s in db.CommunityPtsDocs on z.Id equals y.CommnunityPtId into k
                                     from t in (from r in k where r.CommunityId == id select r).DefaultIfEmpty()
                                     where x.TypeId == 1 
                                     select new Points
                                     {
                                         pointId = x.PointId,
                                         pointsDescription = x.PointDescription,
                                         points = x.Points,
                                         dateApplied = t.DateApplied,
                                         pointsEarned = t.PointsEarned,
                                         pointsPending = t.Pending ? true : false,
                                         pointsApproved = t.Approved ? true : false,
                                         notes = t.Notes
    
                                     }).AsEnumerable();
