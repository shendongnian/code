     public static List<DateTime> getLastSevenDate(DateTime currentDate)
            {
                List<DateTime> lastSevenDate = new List<DateTime>();
                for (int i = 1; i <= 7; i++)
                {
                    lastSevenDate.Add(currentDate.AddDays(-i));
                }
                return lastSevenDate;
            }
