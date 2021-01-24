    [Theory]
    [InlineData(100000, 10, 10000)]
    [InlineData(150000, 15, 12000)]
    [InlineData(210000, 2, 2450)]
    public void IncomeTax_Specs(int annualSalary, int periodPortion, int expectedTaxAmount)
    {
        int actualTaxResult = IncomeTax.GetIncomeTax(annualSalary, periodPortion);
        Assert.Equal(actualTaxResult, expectedTaxAmount);
    }
