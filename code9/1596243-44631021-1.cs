    [OneTimeSetUp]
    public void Initialize() {
        Currency = mocker.CreateInstance<UKCurrency>();
        DenominationFactory = mocker.CreateInstance<DenominationFactory>();
        var currencyMock = mocker.GetMock<UKCurrency>();
        currencyMock.Setup(_ => _.CurrencyDenominations()).Returns(CurrencyDenominations());
    }
