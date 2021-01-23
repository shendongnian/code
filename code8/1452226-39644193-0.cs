        if (int.TryParse(bonusString, out bonus))
        { CalcBonus(salary, bonus); }
        else if((double.TryParse(bonusString, out bonusPercent)))
        { CalcBonus(salary, bonusPercent); }
        WriteLine( "Your new salary is {0:c2}", CalcBonus(salary,bonus));
