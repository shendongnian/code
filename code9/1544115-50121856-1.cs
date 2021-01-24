    public static class CustomGridHelperExtensions
    {
        public static Kendo.Mvc.UI.Fluent.GridBuilder<T> MyGrid<T>(this HtmlHelper helper, string name)
            where T : class
        {
            return helper.Kendo().Grid<T>()
                .Filterable(filterable => filterable
                    .Extra(true)   //This extended "filterable" section of code makes the contains filter the default string filter for these grids
                    .Operators(operators => operators
                        .ForString(str => str
                            .Clear()
                            .Contains("Contains")
                            .DoesNotContain("Does not contain")
                            .StartsWith("Starts with")
                            .EndsWith("Ends with")
                            .IsEqualTo("Is equal to")
                            .IsNotEqualTo("Is not equal to")
                            .IsNull("Is null")
                            .IsNotNull("Is not null")
                        )
                    )
                );
        }
