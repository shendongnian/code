    var timeTables = db.TimeTables
        /*
         * Select is optional; this would improve performance for a table with many 
         * extra properties, but would have little-to-no relevant impacts if you're
         * already using them all. Similar to a SELECT * versus selecting individual
         * columns.
         */
        .Select(c => new {
            c.INN,
            c.StartDay,
            c.StartPause,
            c.EndPause,
            c.EndDay
        })
        .AsEnumerable(); // or ...await ToListAsync();
    var xdoc = new XDocument(
            new XElement("data",
                timeTables.Select(w =>
                    new XElement("worker",
                        new XAttribute("id", w.INN),
                        new XElement("start", w.StartDay),
                        new XElement("pause", w.StartPause),
                        new XElement("continue", w.EndPause),
                        new XElement("end", w.EndDay)
                    )
                )
            )
        );
