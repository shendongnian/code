    IEnumerable<Account> sortedAccounts = accounts
                .Select(x => {
                    x.PersonRoles = x
                    .PersonRoles
                    .OrderBy(acct => {
                        if (acct.PersonNumber != 001)
                            return 999;
                        return acct.RoleOrder;
                    }).ToArray();
                    return x;
                })
                .OrderBy(acct => {                
                    var relevantRoles = acct.PersonRoles
                        .Where(role => role.PersonNumber == 0001)
                        .Select(x => x.RoleOrder);
                    if (relevantRoles.Any() == false)
                        return 999;
                    return relevantRoles.Max();
                    }
                ).ToList();
