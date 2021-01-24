    public static bool IsValid(string person)
    {
        bool empExists = lstAllEmps.Any(x => x.IDNum == person);
        return empExists;
    }
