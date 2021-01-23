    [TestMethod]
    public async Task GetHolidayDates_Should_Only_Return_The_Dates_Within_Given_Range()
    {
        // Arrange.
            SpAsyncEnumerableQueryable<HolidayDate> dates = new SpAsyncEnumerableQueryable<HolidayDate>();
            dates.Add(new HolidayDate() { Date = new DateTime(2018, 05, 01) });
            dates.Add(new HolidayDate() { Date = new DateTime(2018, 07, 01) });
            dates.Add(new HolidayDate() { Date = new DateTime(2018, 04, 01) });
            dates.Add(new HolidayDate() { Date = new DateTime(2019, 03, 01) });
            dates.Add(new HolidayDate() { Date = new DateTime(2019, 02, 15) });
            
    
        var options = new DbContextOptionsBuilder<HolidayDataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    
        HolidayDataContext context = new HolidayDataContext(options);
    
        context.Dates = context.Dates.MockFromSql(dates);
    
        HolidayDataAccess dataAccess = new HolidayDataAccess(context);
    
        //Act.
        IEnumerable<HolidayDate> resutlDates = await dataAccess.GetHolidayDates(new DateTime(2018, 01, 01), new DateTime(2018, 05, 31));
    
        // Assert.
    
        Assert.AreEqual(resutlDates.Any(d => d.Date != new DateTime(2019, 03, 01)), true);
        Assert.AreEqual(resutlDates.Any(d => d.Date != new DateTime(2019, 02, 15)), true);
    
        // we do not need to call this becuase we are using a using block for the context...
        //context.Database.EnsureDeleted();
    }
