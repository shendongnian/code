           <!-- BEGIN KendoGrid -->
            <div>
                @(Html.Kendo().Grid<SampleViewModel>()
                .Name("KendoGrid")
                .Scrollable()
                .Columns(columns =>
                {
                    columns.Bound("").HtmlAttributes(new { style = "text-align:center;" }).ClientTemplate("<a class='k-button' onclick=\"deleteSample(#=Id#)\"><span class='k-icon k-delete'></span>Delete</a>").Width(85).Sortable(false);
                    columns.Bound("").HtmlAttributes(new { style = "text-align:center;" }).ClientTemplate("<a class='k-button' href=\"/Sample/Edit/#= Id #\"><span class='k-icon k-edit'></span>Edit</a>").Width(130).Sortable(false);
                    columns.Bound(x => x.Name);
                    columns.Bound(x => x.Code);
                    columns.Bound(x => x.Regex);
                    columns.Bound(x => x.StatusText);
                })
                 .Pageable(pager => pager
                        .Input(true)
                        .Numeric(false)
                        .Info(true)
                        .PreviousNext(true)
                        .Refresh(true))
                    .Scrollable()
                    .Sortable()
                    .HtmlAttributes(new { style = "height:480px;" })
                    .DataSource(dataSource => dataSource
                        .Ajax()
                        .PageSize(10)
                        .ServerOperation(true)
                        .Read(read => read.Action("GetSampleList", "Sample"))
                        ))
            </div>
            <!-- END KendoGrid -->
