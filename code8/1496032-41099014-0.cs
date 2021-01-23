     private static Mock<DbSet<T>> GetDbSetMock<T>(IEnumerable<T> items = null) where T : class
            {
                if (items == null)
                {
                    items = new T[0];
                }
    
                var dbSetMock = new Mock<DbSet<T>>();
                var q = dbSetMock.As<IQueryable<T>>();
    
                q.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);
    
                return dbSetMock;
            }
    
    
    
    var mockContext = new Mock<MyDbContext>();
    
    var users = new List<User> { new User { Email = "my@email.com", Id = 1 } };
    
    mockContext.Setup(x => x.Set<User>()).Returns(GetDbSetMock(users).Object);
