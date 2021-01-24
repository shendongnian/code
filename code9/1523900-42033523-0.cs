    Html.MyControls()
        .MyGrid<PersonModel>()
        .Columns<DataTableColumn<PersonModel>>(column =>
        {
            column.Column(w => w.Name);
        })
