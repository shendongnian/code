        if (netIncome < 30000)
        {
            federalTaxRate = 0;
        }
        else if (netIncome < 60000)
        {
            federalTaxRate = .1;
        }
        else if (netIncome < 100000)
        {
            federalTaxRate = .2;
        }
        else if (netIncome < 250000)
        {
            federalTaxRate = .3;
        }
        else //  (netIncome >= 250000)
        {
            federalTaxRate = .4;
        }
