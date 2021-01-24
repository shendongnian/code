                XElement tracks =  cdXml.Root.Element("Tracks");
                List<XElement> query1 = myXMLDoc.Root.Element("album").Element("tracks").Elements("track")
                    .Where(track2 => track2.Element("name").Value.Contains(track.Element("Titel").Value)).ToList();
                foreach (XElement q1 in query1)
                {
                    tracks.Add(new XElement("Artiest", q1.Element("name").Value),
                             new XElement("Titel", q1.Element("artist").Element("name").Value),
                             new XElement("Lengte", q1.Element("duration").Value));
                }
