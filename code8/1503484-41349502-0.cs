    var NewType = new
    {
        NewTypeId = old.SubType?.SubTypeId ?? 0,
        OtherType = old.OtherType ?? "",
        Review = old.CustomerComments ?? "",
        Country = old.Country?.Abbreviation ?? "",
        Customer = old.SubType?.Customer?.Name ?? ""
    };
