    [TestCase(1)]
    [TestCase(10)]
    [TestCase(50)]
    public void AmountAboveZero_InsertToUserBalance(decimal number)
    {
        //Arrange 
        var user = new User(1, "FirstName", "Surname", "tst", "tst@example.com", 0);
        var icTransaction = new InsertCashTransaction(user, DateTime.Now, number);
        // Act
        icTransaction.Execute();
        //Assert
        Assert.AreEqual(number, user.Balance);
    }
