    var adviceLineCallTotalViewModelList = db.AdviceLineCalls
      .Where( a=> a.Staff.Employed)
      .Select(a => new {
        a.AdviceLineCallId,
        a.SubjectMatter.AdviceLineCallSubjectMatterID,
        a.SubjectMatter.AdviceLineCallSubjectMatterDesc,
        a.StatusOfAdviceLineCaller.StatusOfAdviceLineCallerID,
        a.StatusOfAdviceLineCaller.StatusOfAdviceLineCallerDesc,
        a.Agency.AgencyNumber,
        a.Agency.AgencyNumberNameFacility,
        a.CallDate,
        a.CallLength,
        a.Comments,
        a.Staff.StaffID,
        a.Staff.LastName})
      .ToList() // I'd recommend using .Take() to limit the # of rows returned.
      .Select(x => new AdviceLineCallTotalViewModel()
       {
           AdviceLineCallID = x.AdviceLineCallID,
           AdviceLineCallSubjectMatterID = x.AdviceLineCallSubjectMatterID,
           AdviceLineCallSubjectMatterDesc = x.AdviceLineCallSubjectMatterDesc,
           StatusOfAdviceLineCallerID = x.StatusOfAdviceLineCallerID,
           StatusOfAdviceLineCallerDesc = x.StatusOfAdviceLineCallerDesc,
           AgencyNumber = x.AgencyNumber,
           AgencyNumberNameFacility = x.AgencyNumberNameFacility,
           CallDate = x.CallDate,
           CallLength = x.CallLength,
           Comments = x.Comments,
           StaffID = x.StaffID,
           LastName = x.LastName
       });
