        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50)]
        public void AmountAboveZero_InsertToUserBalance(decimal number)
        {
            //Arrange 
            IUser user = Substitute.For<IUser>();
            InsertCashTransaction icTransaction = new InsertCashTransaction(user, null, number);
            user.Balance = 0;
            decimal actualresult = number;
            // Act
            // Somewhere here it goes wrong
            icTransaction.Execute();
            //Assert
            Assert.AreEqual(actualresult, user.Balance);
        }
