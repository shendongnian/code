    int outer = 0;
    
    while (outer < accInfo.Count - 1)
    {
        if (accInfo[outer].AccountNumber == accInfo[outer + 1].AccountNumber && accInfo[outer].EndDate == accInfo[outer + 1].StartDate)
        {
            if (resultAccInfo.Count == 0)
            {
                resultAccInfo.Add(new AccountInformation()
                {
                    AccountNumber = accInfo[outer].AccountNumber,
                    StartDate = accInfo[outer].StartDate,
                    EndDate = accInfo[outer + 1].EndDate
                });
            }
    
            else
            {
                resultAccInfo[resultAccInfo.Count - 1].EndDate = accInfo[outer + 1].EndDate;
            }
    
            outer++;
        }
        else
        {
            resultAccInfo.Add(new AccountInformation()
            {
                AccountNumber = accInfo[outer + 1].AccountNumber,
                StartDate = accInfo[outer + 1].StartDate,
                EndDate = accInfo[outer + 1].EndDate
            });
    
            outer++;
        }
    }
