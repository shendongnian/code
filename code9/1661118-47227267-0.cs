    var start = DateTime.ParseExact("15-10-2017", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    var end = DateTime.ParseExact("15-11-2017", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    var dateFromtable = DateTime.ParseExact([DATE_FROM_TABLE], "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    
    Assert.That(dateFromtable  >= start && dateFromtable < end, Is.True);
