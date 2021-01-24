    var model = data.GroupBy(_ => _.Section.SectionName)
        .Select(section => new MyMainViewModel {
            Location = section.Key,
            Children = section.GroupBy(_ => new {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_.DateEntered.Month),
                Year = _.DateEntered.Year.ToString()
            }).Select(period => new MyChildViewModel {
                Month = period.Key.Month,
                Year = period.Key.Year,
                TotalPhoneCalls = period.Sum(_ => _.PhoneCallsTaken)
            }).ToList()
        });
