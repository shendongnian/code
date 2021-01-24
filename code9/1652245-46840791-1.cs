     private Mock<IWorldContext> _context;
     private WorldRepository _repo;
    
            [TestMethod]
            public void Test_AddTrips()
            {
                ////Arrange          
    
                var data = new List<Stop> {
                     new Stop
                    {
                        Arrival = DateTime.Now.AddDays(-15),
                        Id = 1,
                        Latittude = 0.05,
                        Longitude = 0.004,
                        Name = "Test Trip01",
                        Order = 1
                    },
                       new Stop
                    {
                        Arrival = DateTime.Now.AddDays(-20),
                        Id = 2,
                        Latittude = 0.07,
                        Longitude = 0.015,
                        Name = "Test Trip02",
                        Order = 2
                    }
    
                }.AsQueryable();
              
                var mockSet = new Mock<DbSet<Stop>>();
                mockSet.As<IQueryable<Stop>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<Stop>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Stop>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Stop>>().Setup(m => m.GetEnumerator()).Returns( data.GetEnumerator());
    
                _context = new Mock<IWorldContext>();
                _context.Setup(c => c.Stops).Returns(mockSet.Object);
    
                _repo = new WorldRepository(_context.Object);    
    
    
                //Act
                _repo.AddSop("Sydney",
                    new Stop
                    {
                        Arrival = DateTime.Now,
                        Id = 2,
                        Latittude = 0.01,
                        Longitude = 0.005,
                        Name = "Test Trip",
                        Order = 5
                    });
    
                _repo.SaveChangesAsync();
    
                var count = _repo.GetAllTrips().Count();
    
                //Assert
                Assert.AreEqual(3, count);
    
    
            }
