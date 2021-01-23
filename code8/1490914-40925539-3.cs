     var items=new List<Result>();
            foreach (var item in result)
            {
                items.Add(new Result {Id=-1, Name=item.Key});
                items.AddRange(item.ToList().Select(subItem => new Result {Id = subItem.Id, Name = subItem.Name}));
                //You can add your blank record here. but not sure exact logic 
            }
