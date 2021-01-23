    @Html.Grid(Model.Where(d=>d.HasVisited==true)).Named("Grid1").Columns(columns =>
                     {
                        columns.Add(c => c.StartTime).Titled("Date").Filterable(true).Sortable(true);
                        columns.Add(c => c.Patient).Titled("Patient").Filterable(true).Sortable(true);
                    }).WithPaging(10).Sortable(true)
