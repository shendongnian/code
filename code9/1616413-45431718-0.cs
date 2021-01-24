    <Removed GetReqAppMapList>--bad idea
    public static IEnumerable<TicketApplication> GetApplicationList(int aiDocumentTypeId, int aiApplicationTypeId, int aiRequestTypeId)
    {
        try
        {
           //This is the magic potion...
           List<int?> appmap = new List<int?>();
           var applist = (from ram in applicationentity.ReqAppMaps
                          where ram.RequestTypeId == aiRequestTypeId
                           && ram.IsActive == 1
                          select new AppMap
                          {
                             ApplicationTypeId = ram.ApplicationTypeId
                          }).ToList();
          foreach (var item in applist)
          {
             appmap.Add(item.ApplicationTypeId);
          }
          //magic potion end
          var applicationlist = new List<TicketApplication>();                    
          using (var applicationentity = new eRequestsEntities())
          {                 
             applicationlist = (from app in applicationentity.Applications
                                where 1==1
                            ===>>>&& appmap.Contains(app.ApplicationTypeId)<<<===
                                 && app.IsActive == 1
                                   select new TicketApplication
                                   {
                                       ApplicationId = app.ApplicationId,
                                       Description = app.Description,
                                       DeliveryGroupId = app.DeliveryGroupId,
                                       ApplicationTypeId =app.ApplicationTypeId,
                                       DeliveryTypeId = app.DeliveryTypeId,
                                       DocumentTypeId = app.DocumentTypeId,
                                       SupportGroupId = app.SupportGroupId
                                   }).OrderBy(a => a.Description).ToList();
                return applicationlist;
    }
