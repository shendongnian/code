    @(Html.Kendo().Grid<Models.ViewModels.NPIModel>()
            .Name("npi-grid")
            .Columns(columns =>
            {
                columns.Bound(c => c.FirstName)
            })
        )
