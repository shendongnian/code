    var perclist = list.GroupBy(i=>i.RoleName)
          .Select(i=> 
                new { 
                     rolename=i.Key, 
                     perc = ((double)(i.Count()) / (double)(list.Count()) )*100
                });
    var json = JsonConvert.SerializeObject(perclist);
