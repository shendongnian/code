    internal static IEnumerable<string[]> GetTestDataForSpecificItemType(ItemTypes itemTypeCode)
            {
                var data = DataGetter.GetTestData("MyTestData");
                data = data.Where(x => x.ItemTypeCode.Trim() == itemTypeCode.ToString());
                var z = data.GroupBy(x => new{x.AccessionNumber})
                    .Select(x => new StudentAssessmentTestData(){ AccessionNumber = x.Key.AccessionNumber, LoginId = x.FirstOrDefault().LoginId});
    
                foreach (var record in z)
                {
                    yield return new[] { record.AccessionNumber, record.LoginId };
                }
            }
