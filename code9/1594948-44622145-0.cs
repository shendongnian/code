    IEnumerable<StudentAssessmentTestData> data = DataGetter.GetTestData("MyTestData");
    data = data.Where(x => x.ItemTypeCode.Trim() == itemTypeCode.ToString());
    var z = data.GroupBy(x => x.AccessionNumber).SelectMany(y => y.Take(1));
    foreach (var record in z)
    {
        yield return new[] { record.AccessionNumber, record.LoginId };
    }
    
