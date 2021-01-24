            string[] entries =
            {
                "2017-03-21 17:14:36.380 I like Red",
                "2017-03-21 17:14:35.380 I like Yellow",
                "2017-03-21 17:14:36.380 I like Green"
            };
            var data = new List<Tuple<DateTime, string>>();
            foreach (var entry in entries)
            {
                data.Add(
                    new Tuple<DateTime, string>(DateTime.Parse(entry.Substring(0, 23)), 
                    entry.Substring(23)));
            }
            var sorted = data.OrderBy(e => e.Item1);
