    @(Html.Kendo().Grid<Models.ViewModels.PecosViewModel>()
            .Name("npi-grid")
            .Columns(columns =>
            {
                columns.Bound(c => c.NpiList)
            })
        )
