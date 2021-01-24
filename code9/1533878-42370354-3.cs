            foreach(var item in managers)
            {
                foreach(var subitem in item)
                {
                    CalendarModel c = subitem;
                    Console.WriteLine(c.date);
                }
            }
