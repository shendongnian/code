    @model Models.ViewModels.PecosViewModel
    @(Html.Kendo().Grid(Model.NpiList)
            .Name("npi-grid")
            .Columns(columns =>
            {
                columns.Bound(c => c.NPI)
            })
        )
