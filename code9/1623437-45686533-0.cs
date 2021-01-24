    var timeTables = db.TimeTables.ToList(); // or ...await...Async();
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
