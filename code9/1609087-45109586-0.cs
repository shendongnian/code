    public override bool IsValid(object value)
    {
        // Validate that user input is in the list of allowed values
        var allowedList = MakeModelHelpers.GetActiveMakeModelInfo();
        var userInput = value as string;
        var isValid = allowedList.Any(i -> i.Make == userInput || i.Model == userInput);
        return isValid;
    }
