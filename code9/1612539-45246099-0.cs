    using System.Collections.Generic;
    using System.Linq;
    var expectedRecords = new List<string> { "A", "B", "C", "D" };
    var actualRecords   = new List<string> { "A", "C", "E" };
    //var actualRecords = table.FindElements(".//tr//td[1]")
    //                         .Select(e => e.GetAttribute("innerHTML"))
    //                         .ToList();
    var notFoundRecords = expectedRecords.Except(actualRecords); // [ "B", "D" ]
    var invalidRecords  = actualRecords.Except(expectedRecords); // [ "E" ]
