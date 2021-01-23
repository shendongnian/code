    var accounts = (from a in entityRepository.Queryable<Account>()
                from l in a.ExternalLogins.DefaultIfEmpty() 
                select new
                {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName,
                    Status = a.Status == AccountStatus.Closed ? Enums.Status.Inactive : Enums.Status.Active,
                    Login = (l == null) ? null : new
                    {   
                        ConnectionID = l.Connection.ID,
                        l.Connection.ConnectionType,
                        l.Identity    
                    },
                    a.AdminAccess,
                    a.Username,
                    a.Email
                }).ToList();
