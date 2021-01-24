    // Parsed holidays in a list, we will use LINQ against it.
    var holidays = new List<DateTime> {
        new DateTime(2017, 1, 19),
        new DateTime(2017, 1, 20),
    };
    // Selected Date. In your case it would be: DateTime.Parse(txtDate.Text);
    var selectedDate = new DateTime(2017, 1, 16);
    // Count how many holidays there are within 3 days from the selcted date.
    var count = holidays.Count(holiday => holiday - selectedDate <= TimeSpan.FromDays(3));
    // Then add the count and 3 to the selected date
    var closingDate = selectedDate.AddDays(count + 3);
    // Now we have to make sure the closing date is not a holiday.
    int skipDays = 0;
    while (holidays.Any(holiday => holiday == closingDate.AddDays(skipDays)))
    {
        // holidays list contains the date. Skip it.
        skipDays++;
    }
    closingDate = closingDate.AddDays(skipDays);
