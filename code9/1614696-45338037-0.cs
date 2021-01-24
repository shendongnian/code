     var results = from client in _db.Clients
                                  join trade in _db.Payments on client.Id equals trade.ClientId
                                  where (client.Id == trade.ClientId &&
                                  DateTime.Compare(trade.TradeDate, (DateTime)fromDate) >= 0 &&
                                  DateTime.Compare(trade.TradeDate, (DateTime) toDate) <= 0)
                                  select new { client.Username, trade};
                    var cs = results
                        .GroupBy(tr => new {id=tr.trade.ClientId,name=tr.trade.Name})
                        .Select(item => new Totals
                        {
                            Username = item.Key.name
                            CommBcf = item.Sum(client => client.trade.CommBcf),
                            EcnAll = item.Sum(client => client.trade.EcnAll),
                            EcnRbt = item.Sum(client => client.trade.EcnRbt),
                            OpenGross = item.Sum(client => client.trade.OpenGross),
                            CloseGross = item.Sum(client => client.trade.CloseGross)
        }).ToList();
