       public async Task<PortfolioLoans> GetSampleOfPortfolioLoanNumbers(int count = 1)
       {
      
            var pfLoans;
            try
            {
               pfLoans = await Task.Run(() => {
                  var sqlConn = new SqlConnection(this.DataMineConnectionString);
                  var pls = new Portfolioloans();
                  for(var i=0; i<count; i++)
                  {
                      var loans = await sqlConn.QueryAsync("dbo.spGetSampleApplicationIDs", Parameters.Empty, Query.Returns<PortfolioLoan>());
                      pls.Loans.AddRange(loans);
                  }
                 return pls;
          });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return pfLoans;
    }
