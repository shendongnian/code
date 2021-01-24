    var totals = from client in _db.Clients
                             join bank in _db.Banking on client.Id equals bank.ClientId into banks
                             from bank in banks.DefaultIfEmpty()
                             where (client.Id == bank.ClientId &&
                                    DateTime.Compare(bank.BankDate, (DateTime)fromDate) >= 0 &&
                                    DateTime.Compare(bank.BankDate, (DateTime)toDate) <= 0)
                             join market in _db.Marketing on client.Id equals market.ClientId into markets
                             from market in markets.DefaultIfEmpty()
                             where (client.Id == market.ClientId &&
                                    DateTime.Compare(market.MarketDate, (DateTime)fromDate) >= 0 &&
                                    DateTime.Compare(market.MarketDate, (DateTime)toDate) <= 0)
                             select new { client.Username, bank, market };
