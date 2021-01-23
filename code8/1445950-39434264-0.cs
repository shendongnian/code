            XDocument oldDoc = XDocument.Load(PathOld);
            var stGroup = oldDoc.Descendants("row").GroupBy(row =>
                 new { s = row.Descendants("school").First().Value, g = row.Descendants("grade").First().Value },
                 (key, gr) => new { key, list = gr}
                 );
            XDocument newDoc = new XDocument();
            var root = new XElement("root");
            foreach (var item in stGroup)
            {
                var row = new XElement("row");
                row.Add(new XElement("school"), item.key.s);
                row.Add(new XElement("grade"), item.key.g);
                var stds = new XElement("students");
                foreach (var stud in item.list)
                {
                    stds.Add(new XElement("student_name",
                        stud.Descendants("student_name").First().Value));
                }
                row.Add(stds);
                root.Add(row);
            }
            newDoc.Add(root);
            newDoc.Save(PathNew);
