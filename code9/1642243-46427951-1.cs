    [TestMethod]
    public void Verify_Valid_Amount_Results_In_Widtdrawal()
    {
         var bankAccount = new BankAccount();
         var withdrawal = bankAccount.WithdrawMoney(1200);
         Assert.IsNotNull(withdrawal);
         Assert.AreEqual(1200, withdrawal);
    }
    
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Verify_Valid_Amount_Results_In_Exception()
    {
         var bankAccount = new BankAccount();
         var withdrawal = bankAccount.WithdrawMoney(800);
    }
