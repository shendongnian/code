    DateTime tmpRenewal = contractRenewal;
    while(tmpRenewal > DateTime.Now)
    {
        tmpRenewal = tmpRenewal.AddMonths(-MonthsInBillPeriod);
    }
    // need to go one period forward, to the future from Now (as we are in the past right now)
    DateTime renewal = tmpRenewal.AddMonths(MonthsInBillPeriod).AddDays(-1);
