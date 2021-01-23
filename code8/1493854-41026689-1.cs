    var mockStatementInformation = Mock.Of<IStatementInformation>(m =>
        m.Navigation == new Navigation { IsNew = false } &&
        m.Navigation.IsCurrentStepUnlocked() == false
    );
    Assert.IsFalse(mockStatementInformation.Navigation.IsCurrentStepUnlocked());
    Assert.IsFalse(mockStatementInformation.Navigation.IsNew);
