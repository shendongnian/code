    [Fact]
    public void Bill_DayCount_IsCorrect()
    {
        // Arrange
        var repository = new Repository();
        var bill = new Bill
        {
            StartDate = DateTime.Parse("1/1/2018"),
            EndDate = DateTime.Parse("29/1/2018"),
        };
        // Act
        var result = repository.GetBillDayCount(bill);
       // Assert
       Assert.Equal(28, result.DayCount);
    }
