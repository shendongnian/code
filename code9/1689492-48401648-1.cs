    var destinations = list.GroupBy(x => new {x.AppName,x.Role})
                            .Select(x => new Destination
                                {
                                    AppName = x.Key.AppName,
                                    Role = x.Key.Role,
                                    UserNames = x.Select(y => y.UserName).ToList(),
                                    Actions = x.Select(y => y.Action).ToList()
                                })
                            .ToList();
