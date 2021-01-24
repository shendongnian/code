    List<MyClass> date = new List<MyClass>
    {
        new MyClass { Date = new DateTime(2017,03,04), Code = "1234"},
        new MyClass { Date = new DateTime(2017,03,05), Code = "1234"},
        new MyClass { Date = new DateTime(2017,03,06), Code = "1234"},
        new MyClass { Date = new DateTime(2017,04,04), Code = "1234"},
        new MyClass { Date = new DateTime(2017,04,05), Code = "1234"},
        new MyClass { Date = new DateTime(2017,04,06), Code = "1234"},
        new MyClass { Date = new DateTime(2017,03,06), Code = "12345"},
        new MyClass { Date = new DateTime(2017,04,04), Code = "12345"},
        new MyClass { Date = new DateTime(2017,04,05), Code = "12345"},
        new MyClass { Date = new DateTime(2017,04,06), Code = "12345"}
                };
    
    var groupbydata = date.GroupBy(x => x.Code).ToDictionary(x => x.Key, x => x.GroupBy(y => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(y.Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday) + y.Date.Year));
