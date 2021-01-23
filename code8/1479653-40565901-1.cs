    var logList = service.GetLogDetails()
                         .Where(item => Userid == 0 || item.Id = Userid)
                         .ToList();
   
    var usernames = (from A in logList 
                     orderby A.FirstName 
                     select new { Name = $"{A.FirstName} {A.SurName}", ID = A.Id }).Distinct();
    var loginDate = (from A in logList 
                     select A.LogInTime.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Distinct();
    var logOutDate = (from A in logList 
                      select (A.LogOutTime ?? "Unknown").ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Distinct();
