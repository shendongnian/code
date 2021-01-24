    var loCarsCategories = loDt.AsEnumerable()
        .GroupBy(row => new { CategoryName = row.Field<string>("CategoryName") })
        .Select(catGroup => new CarCategory
        {
            CategoryName = catGroup.Key.CategoryName,
            CarGroups = new List<CarGroup>(catGroup
                .GroupBy(row => new { GroupName = row.Field<string>("GroupName") })
                .Select(groupGroup => new CarGroup
                {
                    GroupName = groupGroup.Key.GroupName,
                    CarTests = new List<CarTest>(groupGroup
                        .GroupBy(row => new { TestName = row.Field<string>("TestName") })
                        .Select(groupTest => new CarTest
                        {
                            TestName = groupTest.Key.TestName,
                            CarTestNumbers = new List<CarTestNumber>(groupTest
                                .Select(row => new CarTestNumber
                                {
                                    TestNumber = row.Field<String>("TestNumber"),
                                    TestVisitCode = row.Field<String>("TestVisitCode")
                                })
                                .Union(new List<CarTestNumber>(loTestVisitCodes
                                    .Except(groupTest.Select(row => row.Field<string>("TestVisitCode")))
                                    .Select(VisitCode => new CarTestNumber
                                    {
                                        TestNumber = string.Empty,
                                        TestVisitCode = VisitCode
                                    }))))
                        }))
                }))
        });
