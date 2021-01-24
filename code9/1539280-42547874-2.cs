     int total =0;
                var strlist = new [] { "2017 / 01 / 01T00:00:00", "2017 / 02 / 01T00: 00:00" };
                foreach (var date in strlist)
                {
                    var datetime = Convert.ToDateTime(date);
                    if (datetime.Year == 2017)
                    {
                        total++;
                    }
                }
                if (total <12)
                {
                    throw new Exception("Please enter all months");
                }
