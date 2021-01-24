    @if (Model.ReadOnly)
    {
        @Html.DropDownListFor(model => model.Project.Status,
                              Model.Statuses,
                              "--",
                              new { @disabled = "disabled" })
    }
    else
    {
        @Html.DropDownListFor(model => model.Project.Status,
                              Model.Statuses,
                              "--")
    }
