    // Using LINQ
        SomeObjCollection.AddAll(DataGridView.Rows
            .Select(currRow => new SomeObject(CurrRow.DataBoundItem)
            {
                  PropertyA = 0;
                  PropertyB = 0;
            });
    
    // Using yield (I'd use LINQ personally as this is reinventing the wheel)
    // But sometimes you want to use yield in your own extension methods
    IEnumerable<SomeObject> RowsToSomeObject()
    {
        foreach (var currRow in DataGridView.Rows)
        {
            yield new SomeObject(CurrRow.DataBoundItem)
            {
                  PropertyA = 0;
                  PropertyB = 0;
            }
        }
    }
    // and then later in some method:
    SomeObjCollection.AddAll(RowsToSomeObjects())
