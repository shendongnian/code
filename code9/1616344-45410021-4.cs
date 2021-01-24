    [Fact]
    public async Task Cancel_StatusShouldBeN()
    {
        var logger = new LoggerFactory().CreateLogger<ExampleService>();
        var dbOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase();
        // arrange
        using (var db = new MyDbContext(dbOptionsBuilder.Options))
        {
            // fix up some data
            db.Set<SomeItem>().Add(new SomeItem()
            {
                Id = 5,
                Status = "Not N"
            });
            await db.SaveChangesAsync();
        }
        using (var db = new MyDbContext(dbOptionsBuilder.Options))
        {
            // create the service
            var service = new YourService(logger, db);
            // act
            var result = service.Cancel(5);
            // assert
            Assert.Equal(1, result);
        }
        using (var db = new MyDbContext(dbOptionsBuilder.Options))
        {
            var item = db.Set<SomeItem>().Find(5);
            Assert.Equal(5, item.Id);
            Assert.Equal("n", item.Status);
        }
    }
