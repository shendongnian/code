    public IEnumerable<ReportMapper> FetchReports(DateTime startDate, DateTime endDate, int docMode, int pageNumber, bool flag)
    {
        using (var entities = new DatabaseEntities1())
        {
            IQueryable<ReportMapper> reports = 
                      from c in entities.tDocumentStatus
                      join d in entities.tTOCStructures on c.DocumentId equals d.DocumentID
                      join e in entities.tUsers on d.LastUpdatedBy equals e.UserUID
                      orderby c.AssignedDate descending
                      where c.AssignedDate >= startDate && c.AssignedDate <= endDate
                      select new ReportMapper()
                      {
                          DocumentName = d.FolderName,
                          AssignedDate = c.AssignedDate,
                          ReviewStatus = c.tStatu.StatusName,
                          ActionPerformedBy = e.FirstName + " " + e.LastName
                      };
            if (docMode > 0)
                reports = reports.Where(r => c.StatusId == docMode);
            if(!flag)
                reports = reports.Skip(pageNumber * 10).Take(50);
            return reports.ToList();
        }
    }
