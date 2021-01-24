    public bool Equals(Person other)
    {
        if (other == null) return false;
        return FirstName == other.FirstName
            && LastName == other.LastName
            && IdNumber == other.IdNumber
            && Address == other.Address;
    }
    
    public bool Equals(Employee other)
    {
        if (other == null) return false;
        return base.Equals(other)
            && SalaryPerHour == other.SalaryPerHour // ; removed
            && HoursPerMonth == other.HoursPerMonth;
    }
    
    public bool Equals(Seller other)
    {
        if (other == null) return false;
        return base.Equals(other)
            && SalesGoal == other.SalesGoal // SalaryPerHour;
            && MetSaleGoleLastYear == other.MetSaleGoleLastYear; //HoursPerMonth;
    }
