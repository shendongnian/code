    //PART0: collecting data 
    var holidayDateDates = list.Select(x => x.HolidayDate).ToList();
    var replacementDates = list.Select(x => x.ReplacementDate).Where(y => y != null).ToList().ConvertAll<DateTime>(x => x.Value);
    holidayDateDates.AddRange(replacementDates);
    //PART1: return list of the actual duplicate values
    var result = holidayDateDates.GroupBy(x => x)
        .Where(g => g.Count() > 1)
        .Select(y => y.Key)
        .ToList();
    var duplicateDates = string.Join(", ", result.ToString("yyyy-MM-dd"));
    
    //PART2: return a list with the items that have a duplicate item
    var dummytime = new DateTime();// this will never be in the list and kills all nulls, see below
    var duplicateHolidays = list.Where(x => result.Contains(x.HolidayDate) || result.Contains(x.ReplacementDate??dummytime));
    var resultString = string.Join(", ", duplicateHolidays.Select(q => q.Description));
