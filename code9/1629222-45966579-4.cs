    public static bool IsValid(string person)
    {
        bool empExists = lstAllEmps.Any(x => x.IDNumber == person);
        if (empExists)
        {
            return empExists;
        }
        else
        {
            var exceptionMessage = string.Format("The person, {0}, does not exist!", person);
            throw new ArgumentException(exceptionMessage, person);
        }
    }
