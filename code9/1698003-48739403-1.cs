    var Result= hallDetailsList.OrderBy(item =>
                  {
                      var time = (string)item[3];
                      return DateTime.ParseExact(time, "h:mmtt", null, System.Globalization.DateTimeStyles.None);
                  }).ToList();
