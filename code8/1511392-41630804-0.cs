    public class CustomClass
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<CustomAccesses> Accesses { get; set; }
        }
    
        public class CustomAccesses
        {
            public int Rights { get; set; }
        }
    
    
        public class Accesses
        {
            public Guid ID { get; set; }
            public Guid UID { get; set; }
            public int Rights { get; set; }
        }
    
        public class User
        {
            public Guid ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool Auth { get; set; }
        }
    
        [TestFixture]
        public class QueryTests
        {
            private static readonly User TrueUser = new User
            {
                ID = Guid.NewGuid(),
                FirstName = "TrueFirstName",
                LastName = "TrueLastName",
                Auth = true
            };
    
            private static readonly User FalseUser = new User
            {
                ID = Guid.NewGuid(),
                FirstName = "FalseFirstName",
                LastName = "FalseLastName",
                Auth = false
            };
    
            private static readonly User[] DbUsersMock =
            {
                TrueUser,
                FalseUser
            };
    
            private static readonly Accesses[] DbAuthTrueMock =
            {
                new Accesses
                {
                    ID = Guid.NewGuid(),
                    UID = TrueUser.ID,
                    Rights = 1
                },
                new Accesses
                {
                    ID = Guid.NewGuid(),
                    UID = TrueUser.ID,
                    Rights = 2
                }
            };
    
            private static readonly Accesses[] DbAuthFalseMock =
            {
                new Accesses
                {
                    ID = Guid.NewGuid(),
                    UID = FalseUser.ID,
                    Rights = -1
                },
                new Accesses
                {
                    ID = Guid.NewGuid(),
                    UID = FalseUser.ID,
                    Rights = -2
                }
            };
    
            [Test]
            public void Test()
            {
                var users = DbUsersMock.AsQueryable();
                
                var authTrue = DbAuthTrueMock.AsQueryable();
                
                var authFalse = DbAuthFalseMock.AsQueryable();
    
    
                var result = users
                    .GroupJoin(
                        authTrue,
                        u => u.ID,
                        ta => ta.UID,
                        (user, accesses) => new
                        {
                            user,
                            accesses = accesses.DefaultIfEmpty()
                        }
                    )
                    .SelectMany(
                        ua => ua
                            .accesses
                            .Select(
                                trueAccess => new
                                {
                                    ua.user,
                                    trueAccess
                                }
                            )
                    )
                    .GroupJoin(
                        authFalse,
                        ua => ua.user.ID,
                        fa => fa.UID,
                        (userAccess, accesses) => new
                        {
                            userAccess,
                            accesses = accesses.DefaultIfEmpty()
                        }
                    )
                    .SelectMany(
                        uaa => uaa
                            .accesses
                            .Select(
                                falseAccess => new
                                {
                                    uaa.userAccess.user,
                                    uaa.userAccess.trueAccess,
                                    falseAccess
                                }
                            )
                    )
                    .Where(
                        uaa => uaa.user.Auth
                            ? uaa.trueAccess != null
                            : uaa.falseAccess != null
                    )
                    .Select(
                        uaa => new
                        {
                            uaa.user.ID,
                            uaa.user.FirstName,
                            uaa.user.LastName,
                            AccessID = uaa.user.Auth
                                ? uaa.trueAccess.ID
                                : uaa.falseAccess.ID,
                            Rights = uaa.user.Auth
                                ? uaa.trueAccess.Rights
                                : uaa.falseAccess.Rights
                        }
                    )
                    .OrderBy(uaa => uaa.ID)
                    .AsEnumerable()
                    .GroupBy(uaa => uaa.ID)
                    .Select(
                        g => new CustomClass
                        {
                            FirstName = g.First().FirstName,
                            LastName = g.First().LastName,
                            Accesses = g
                                .GroupBy(uaa => uaa.AccessID)
                                .Select(
                                    uaa => new CustomAccesses
                                    {
                                        Rights = uaa.First().Rights
                                    }
                                )
                                .ToList()
                        }
                    )
                    .ToArray();
    
                Assert.That(result.Length, Is.EqualTo(DbUsersMock.Length));
            }
        }
