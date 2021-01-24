    @model bool
    @if (Model)`{
    @Html.Encode("Yes")
    }
    @if (Model == false)
    {
   
     @Html.Encode("No")
    }
    [UIHint("_myTemplate")]
    public bool StudentInRoster { get; set; }
    @Html.DisplayFor(c => c.StudentInRoster)
