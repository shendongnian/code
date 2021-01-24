    [OneTimeSetUp]
    public void Initialize() {
        Currency = mocker.CreateInstance<UKCurrency>();
        DenominationFactory = mocker.CreateInstance<DenominationFactory>();
        var currencyMock = Mock.Get(Currency); // returns Mock<UKCurrency>
        currencyMock.Setup(_ => _.CurrencyDenominations()).Returns(CurrencyDenominations());
    }
