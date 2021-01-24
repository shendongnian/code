    @{
        List<string[]> validate_rules = new List<string[]>();
        if (TempData["verification_errors"] != null)
        {
            validation_rules = (List<string[]>)TempData["verification_errors"];
        }
    }
    @foreach (var item in validation_rules)
    {
        <p>@(item[0].ToString() + " " + item[2].ToString())</p>
    }
