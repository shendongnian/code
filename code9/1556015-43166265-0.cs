    from cert in CertPoints
    from comm in cert.CommunityPts.DefaultIfEmpty()
    from doc in comm.CommunityPtsDocs
    where comm.CommunityId == id && cert.TypeId == 1 
    select new Points
    {
        pointId = cert.PointId,
        pointsDescription = cert.PointDescription,
        points = cert.Points,
        dateApplied = comm.DateApplied,
        pointsEarned = comm.PointsEarned,
        pointsPending = comm.Pending ? true : false,
        pointsApproved = comm.Approved ? true : false,
        notes = comm.Notes,
        something = doc.Something
    })
