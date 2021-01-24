    var result = holidayList.GetDuplicates<Holiday, DateTime>().ToList();
    // printing the results
    Console.WriteLine(string.Join(", ", result.Select(q => q.Reference.Description)));
    // printing the values
    var values = result.Select(r => r.Value).Distinct();
    Console.WriteLine(string.Join("\r\n", values.Select(q => $"{q:dd/MM/yyyy}")));
