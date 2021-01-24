    var toRemove = dbContext.AdviserFeeDetailReports
        .Where(x => 
            x.PracticeId == superFund.CompanyID && 
            x.SuperFundId == superFund.SuperFundId);
    dbContext.AdviserFreeDetailReports.RemoveRange(toRemove);
    dbContext.SaveChanges();
