    using (JSEADataContext dc = new JSEADataContext(JSEADBContext.GetConnectionstring()))
                    {
                       var Incident = (from incident in dc.Incidents
                                          from main in dc.Mains.Where(inv => inv.ReportID == incident.reportid).DefaultIfEmpty() 
                                          from teamApproval in dc.TeamsAndApprovals.Where(inv => inv.ReportID == incident.reportid).DefaultIfEmpty() 
                                          where incident.reportid == "123123"
                                          orderby incident.reportid ascending
                                          select new Data
                                          {
          AssessmentFormCount = test(main.str_ReportID, dc) }).ToList<Data>().SingleOrDefault();
    }
     private Dictionary<string, int> test(string ReportID, DataContext dc)
        {
            var ceck = (from assessmentCount in dc.AssessmentForms.AsEnumerable()
                        join panel in dc.masters.AsEnumerable() on assessmentCount.lng_ID equals panel.lng_id
                        into temp
                        from j in temp.DefaultIfEmpty()
                        where assessmentCount.ReportID == ReportID
                        group j by j.desc into grouping
                        select new AssessmentFormCheckedCount
                            {
                                str_Panel = grouping.Key,
                                lng_Count = grouping.Count()
                            }).ToList();
            var t = ceck.ToDictionary(p => p.str_Panel, p => p.lng_Count);
            return t;
        }
