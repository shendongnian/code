    WorkItemCollection wic = query.RunQuery();
    foreach (WorkItem item in wic)
    {
         info += String.Format("{0}\n", item.Title);
         var r = item.Fields.OfType<Microsoft.TeamFoundation.WorkItemTracking.Client.Field>()
                      .Select(x => new
                      {
                          Name = x.Name,
                          Value = x.Value
                          //You can fetch more details here...
                      });
    }
