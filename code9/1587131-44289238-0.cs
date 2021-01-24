            Nullable<DateTime> d;
            d = DateTime.Parse("1996-07-12 00:00:00.000");
            if (d.HasValue)
            {
                Console.WriteLine(d.Value.ToString("dd-MM-yyyy"));
            }
