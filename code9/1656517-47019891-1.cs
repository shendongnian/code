    public ActionResult TestData()
    {
        var PretendDatabaseCall = new List<DataRowModel>
        {
            new DataRowModel{
                Id =1,
                BookingDate =new DateTime(2017,1,1),
                Description ="Booking 1",
                Class="Room"
            },
            new DataRowModel{
                Id =2,
                BookingDate =new DateTime(2017,2,1),
                Description ="Booking 2",
                Class="Room"
            },
            new DataRowModel{
                Id =3,
                BookingDate =new DateTime(2017,3,1),
                Description ="Booking 3",
                Class="Suite"
            },
            new DataRowModel{
                Id =4,
                BookingDate =new DateTime(2017,4,1),
                Description ="Booking 4",
                Class="Room"
            },
        };
        //We can now get the data from the database.  We want to group by class so we can
        //get a summary of items by class rather than a big flat list.  Most LINQ to SQL implementations
        //(e.g. Entity Framework) when working with Raw entities could convert this to SQL so the SQL server
        //does the grouping, but if not it can happen in memory (get all records, then standard LINQ does it on
        //the complete list)
        var dataGroupedByClass = PretendDatabaseCall
            //Minor Edit: apply filtering here not in the view!
            .Where(x=>x.BookingDate >= Datetime.Now)
            //Group by class.
            .GroupBy(x => x.Class)
            //for each class, get the records.
            .Select(grpItem => new GroupedDataRowModel()
            {
                //'key' is the thing grouped by (class)
                Class = grpItem.Key,
                //grpItem has all the rows within it accessible still.
                Rows = grpItem.Select(thisRow => thisRow)
            });
        var model = new DataRowsViewModel
        {
            Results = dataGroupedByClass
        };
        return View("~/Views/Home/TestData.cshtml", model);
    }
