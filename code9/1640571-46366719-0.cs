    var model = data.GroupBy(_ => _.Section.SectionName)
        .Select(section => new MyMainViewModel {
            Location = section.Key,
            Children = section.GroupBy(_ => new {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_.DateEntered.Month),
                Year = _.DateEntered.Year
            }).Select(period => new MyChildViewModel {
                Month = period.Key.Month,
                Year = period.Key.Year.ToString(),
                TotalPhoneCalls = period.Sum(g => g.PhoneCallsTaken)
            })
        });
