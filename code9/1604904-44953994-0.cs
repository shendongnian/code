    public static string ReturnAgeGroup(int age)
    {
        if (age >= 65)
        {
            return "senior citizen";
        }
        if (age < 21)
        {
            return "minor";
        }
        return "adult";
    }
