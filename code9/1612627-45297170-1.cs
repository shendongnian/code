    public static Kendo.Mvc.UI.Fluent.GridBuilder<T> MyGrid<T>(this HtmlHelper helper, string name)
                where T : class
            {
                return helper.Kendo().Grid<T>()
                    .Name(name)
                    .Groupable()
                    .Pageable()
                    .Sortable()
                    .Scrollable()
                    .Filterable()
                    .Pageable();
            }
