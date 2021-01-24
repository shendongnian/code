    string sDate = "6/6/2016";
            try
            {
                DateTime dt = DateTime.ParseExact(sDate, "d/M/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
