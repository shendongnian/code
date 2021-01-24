            bool ok = true;
            for (int i = 0; i < 20; i++)
            {
                var day1 = new DateTime(2017, 1, 1);
                var day2 = new DateTime(2017, 4, 1 + i);
                var test = Extensions.GetMonthsInRange(day1, day2);
                var res = day1.AddMonths(test);
                var check = DateTime.Compare(day2.Date, res.Date);
                if (check != 0)
                {
                    ok = false;
                    break;
                }
            }
