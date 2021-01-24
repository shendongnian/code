        if (netIncome < 30_000)
        {
            federalTaxRate = 0;
        }
        else if (netIncome < 60_000)
        {
            federalTaxRate = .1;
        }
        else if (netIncome < 100_000)
        {
            federalTaxRate = .2;
        }
        else if (netIncome < 250_000)
        {
            federalTaxRate = .3;
        }
        else //  (netIncome >= 250000)
        {
            federalTaxRate = .4;
        }
