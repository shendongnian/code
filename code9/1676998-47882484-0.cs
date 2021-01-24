            int inc = 15;
            DateTime startTime = DateTime.Today;//new DateTime(2013,9,6,18,40,0,DateTimeKind.Local);//DateTime.Today.AddHours(10).AddMinutes(50);
            DateTime endTime = DateTime.Today.AddHours(18).AddMinutes(35);//DateTime.Now;
            List<DateTime> timeList = new List<DateTime>();
            //while (startTime < DateTime.Now.AddMinutes(inc))
            for (DateTime i = startTime; i < endTime; i = i.AddMinutes(inc))
            {
                Console.WriteLine(i.ToString("HH:mm:sss"));
            }
