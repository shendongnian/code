     XDocument quotesDoc = XDocument.Parse('your path');
            List<Custom.Quote> quotes = speakersDoc.Root
                 .Elements("quote")
                 .Select(x => new Speaker
                 {
                     Content= (string)x.Attribute("Content"),
                     Author = (string)x.Attribute("Author")
                 })
                 .ToList<Custom.Quote>();
