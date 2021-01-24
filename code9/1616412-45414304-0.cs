    using (var applicationentity = new eRequestsEntities())
    {                 
        applicationlist = (from app in applicationentity.Applications
                           join ram in applicationentity.ReqAppMaps on app.ApplicationTypeId equals ram.RequestTypeId
                            where ram.IsActive == 1 && app.IsActive == 1
                           select new TicketApplication
                           {
                               ApplicationId = app.ApplicationId,
                               Description = app.Description,
                               DeliveryGroupId = app.DeliveryGroupId,
                               ApplicationTypeId = app.ApplicationTypeId,
                               DeliveryTypeId = app.DeliveryTypeId,
                               DocumentTypeId = app.DocumentTypeId,
                               SupportGroupId = app.SupportGroupId
                           }).OrderBy(a => a.Description).ToList();
