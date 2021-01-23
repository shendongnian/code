        public IEnumerable<ReportMapper> FetchReports(DateTime startDate, DateTime endDate, int docMode, int pageNumber, bool flag) {
            try {
                IEnumerable<ReportMapper> reports;
                using (var entities = new DatabaseEntities1()) {
                    var query = (from c in entities.tDocumentStatus
                        join d in entities.tTOCStructures on c.DocumentId equals d.DocumentID
                        join e in entities.tUsers on d.LastUpdatedBy equals e.UserUID
                        orderby c.AssignedDate descending
                        where c.AssignedDate >= startDate && c.AssignedDate <= endDate && (docMode <= 0 || c.StatusId == docMode)
                        select new ReportMapper() {
                            DocumentName = d.FolderName,
                            AssignedDate = c.AssignedDate,
                            ReviewStatus = c.tStatu.StatusName,
                            ActionPerformedBy = e.FirstName + " " + e.LastName
                        });
                    if (!flag)
                        query = query.Skip(pageNumber*10).Take(50);
                    reports = query.ToList<ReportMapper>();
                    return reports;
                }
            }
            catch (Exception ex) {
                //handle exception
            }
        }
