    @model List<Property>
    @if (Model != null && Model.Any())
    {
        foreach (var item in Model)
        {
            <p>@item.Details</p>
            <p>@item.PropertyId</p>
        }
    }
    
    else
    {
        <p>No properties found!</p>
    }
