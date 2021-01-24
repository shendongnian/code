    private string[] LoadErrors()
    {
        var errorList = ModelState
                     .Where(x => x.Value.Errors.Count > 0)
                     .ToDictionary(
                         kvp => kvp.Key,
                         kvp => kvp.Value.Errors.Select(e => 
                         e.ErrorMessage).ToArray()
                     );
        return errorList;
    }
