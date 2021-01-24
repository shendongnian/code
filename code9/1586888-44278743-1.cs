    var taskMessages = from d in result
                       join ptask in db.ListingTask.Entites on new
                       {
                          d.Id,
                          TaskType = ListingTaskType.Offer.ToString()
                       } equals new
                       {
                           Id = ptask.DraftId,
                           ptask.TaskType
                       } into temp
                       from t in temp.DefaultIfEmpty()
                       select new 
                       {
                           // you would obviously need better names
                           object1 = t,
                           object2 = d
                       };
