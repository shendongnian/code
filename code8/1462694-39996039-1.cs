                DateTime currDate = new DateTime(2017, 1, 1); //initial value
                int dayOfWeek = (int)currDate.DayOfWeek;
                currDate = currDate.AddDays(6 - dayOfWeek);
                //add days to MyCalendar
                while (currDate <= new DateTime(2017, 12, 31))
                {
                    MyCalendar.Add(currDate);
                    currDate = currDate.AddDays(7);
                }
                var result = MyCalendar.GroupBy(x => x.Month).Select(x => x.Skip(1).First().Day <= 9 ? new DateTime[] { x.Skip(2).First(), x.Skip(4).First() } : new DateTime[] { x.Skip(1).First(), x.Skip(3).First() }).SelectMany(x => x).ToList();
                foreach (var d in result)
                {
                    Console.WriteLine("{0} {1}", d.Month, d.Day);
                }
                Console.Read();
