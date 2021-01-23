    from c in entities.tDocumentStatus
                             orderby c.AssignedDate descending
                             where ((EntityFunctions.CreateDateTime(c.AssignedDate.Value.Year, c.AssignedDate.Value.Month, c.AssignedDate.Value.Day, 0, 0, 0) >= EntityFunctions.CreateDateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)) && 
                                 EntityFunctions.CreateDateTime(c.AssignedDate.Value.Year, c.AssignedDate.Value.Month, c.AssignedDate.Value.Day, 0, 0, 0) <= EntityFunctions.CreateDateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0)
                             select new ReportMapper()
                             {
                                 DocumentName = c.CheckoutFolderName,
                                 AssignedDate = c.AssignedDate==null? (EntityFunctions.TruncateTime(c.LastUpdatedOn)):  (EntityFunctions.TruncateTime(c.AssignedDate)),
                             });
