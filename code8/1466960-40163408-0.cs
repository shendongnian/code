        [TestMethod]
        public void BalancePositiveCalculator()
        {
            var balance = 100M;
            var monthlyRepayment = 20M;
            var currentInterestRate = 18.9M;
            var savingsExpected = 24M;
            var fakeCreditCard = new CreditCardGold { Money = 15 };
            var classUnderTestMock = new Mock<IClassUnderTest>();
            classUnderTestMock.Setup(
                test =>
                    test.Calculate(It.IsAny<decimal>(), 
                        It.IsAny<decimal>(), 
                        It.IsAny<decimal>(), 
                        It.IsAny<decimal>(),
                        It.IsAny<decimal>()))
                .Returns(new ClassUnderTest());
            classUnderTestMock.Setup(test => test.InterestPaid).Returns(balance);
            var balancePositiveCalculator = new BalancePositiveCalculator(classUnderTestMock.Object);
            var costs = balancePositiveCalculator.Calculate(fakeCreditCard, balance, monthlyRepayment);
            var savingsActual = classUnderTestMock.Object.InterestPaid - costs.FeesAndInterest;
            savingsActual.ShouldBeInRange(savingsExpected - 1M, savingsExpected + 1M);
        }
