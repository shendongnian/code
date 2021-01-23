    private static IEnumerable<TestCaseData> GetTestDataA()
    {
        yield return new TestCaseData(72.5,   new Func<Qv_ges, double>( qvGesQuer => qvGesQuer.FL.Value ), MAX_DELTA);
        yield return new TestCaseData(169.17, new Func<Qv_ges, double>( qvGesQuer => qvGesQuer.RL.Value ), MAX_DELTA);
        yield return new TestCaseData(241.67, new Func<Qv_ges, double>( qvGesQuer => qvGesQuer.NL.Value ), MAX_DELTA);
        yield return new TestCaseData(314.17, new Func<Qv_ges, double>( qvGesQuer => qvGesQuer.IL.Value ), MAX_DELTA);
    }
    [TestCaseSource( nameof(GetTestDataA) )]
    public void MethodA( double expected, Func<Qv_ges, double> getValue, double latitude)
    { 
        Assert.AreEqual( expected, getValue( Qv_ges_Quer ), latitude );
    }
