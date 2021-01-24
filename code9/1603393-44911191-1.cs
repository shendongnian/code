    @(Html.Kendo().Grid<KendoUIApp3.Models.Eid>()
        .Name("EIDGrid")
        .Columns(columns =>
        {
            columns.Bound(c => c.Breed);            
            columns.Bound(c => c.EIDDate).Format("{0:dd/MM/yy}");            
        })
        .Scrollable(s => s.Height("350px"))
        .Editable(editable => editable.Mode(GridEditMode.InCell).DisplayDeleteConfirmation(false))
        .Pageable()
        .Groupable()
        .Sortable()
        .DataSource(dataSource => dataSource
            .Ajax()
            .Model(model =>
            {
                model.Id(p => p.SireGuid);
            })
            .Read(read => read.Action("EIDRead", "Home"))
            .PageSize(100)
            .Batch(true)
            .Sort(s => s.Add("Breed"))
        ))
