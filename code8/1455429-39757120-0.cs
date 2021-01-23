    var result = list.Aggregate(new List<StatusChange>(),
        (lst, i) =>
        {
            var last = lst.LastOrDefault();
            if (last == null
                    || (last.Id != i.Id 
                        && last.OldStatus != i.OldStatus
                        && last.NewStatus != i.NewStatus))
            {
                lst.Add(i);
            }
            return lst;
        });
