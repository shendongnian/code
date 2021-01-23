    private IQueryable<ConnectionItem> ListItems(DataContext dataContext)
        {
            return dataContext.Connections
                .Join(dataContext.Configurations,
                    connections => connections.ConfigID,
                    config => config.ConfigID,
                    (connections, config) => new {cx = connections, cf = config})
                .Join(dataContext.Users,
                    config => config.cf.UserID,
                    users => users.UserID,
                    (config, users) => new {cf = config, su = users})
                .Where(q => q.su.AccountEventID == 123 && q.cf.cx.Successful == true)
                .GroupBy(g => g.cf.cx.CreatedDate.ToShortDateString())
                .Select(s => new ConnectionItem
                {
                    CreatedDate = s.Key,
                    NumberOfConnections = s.Count()
                });
        }
