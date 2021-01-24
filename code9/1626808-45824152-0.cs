    public static string GetAge(DateTime dob)
    {
                DateTime todayDateUtc = DateTime.UtcNow;
                DateTime pastYearDate;
                int years=0;
                string age;
                int days;
                if(DateTime.UtcNow > dob)
                        years = new DateTime(DateTime.UtcNow.Subtract(dob).Ticks).Year - 1;
    
                    pastYearDate = dob.AddYears(years);
                    days = todayDateUtc.Subtract(pastYearDate).Days;
                    age = years + " years " + days + " days";
              return age;
    }
