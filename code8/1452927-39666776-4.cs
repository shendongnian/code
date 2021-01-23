      public async Task<PortfolioLoans> GetSampleOfPortfolioLoanNumbers(int count = 1)
      {
        var pfLoans = new PortfolioLoan();
        try
        {
              var sqlConn = new SqlConnection(this.DataMineConnectionString);
              var pls = new Portfolioloans();
              for(var i=0; i<count; i++)
              {
                  var loans = await sqlConn.QueryAsync("dbo.spGetSampleApplicationIDs", Parameters.Empty, Query.Returns<PortfolioLoan>());
                  pfLoans.Loans.AddRange(loans);
              }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
    return pfLoans;
    }
