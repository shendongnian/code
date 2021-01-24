    var regPoints = (from x in CertPoints
					 join y in CommunityPts on x.PointId equals y.PointId
					 join s in CommunityPtsDocs on y.Id equals s.CommnunityPtId into k
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
