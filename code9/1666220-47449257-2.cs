    var result = customerContract.GroupBy(item => item.CustomerName)
                                 .Select(group => new Customer {
                                                      Name = group.CustomerName,
                                                      Contracts = group.Select(
                                                           e => new Contract {
                                                               Id = e.ContractId,
                                                               NumberOfProducts = e.NumberOfProducts
                                                           }
                                                      ).ToList()
                                                  })
                                 .ToList();
