    using (StreamReader sr = new StreamReader(@"C:\myfile.xml", true))
            {
                XDocument xDoc = XDocument.Load(sr);
                var allCars = xDoc.Root.Elements();
                var carToUse = allCars.Where(x => x.Attribute("name").Value == "Honda").FirstOrDefault();
                var listCars = carToUse.Descendants("part").ToList();
                var fullCars = allCars.Where(x => x.Descendants("part").Any()).ToList();
                var emptyPermissions = allCars.Where(x => x.Descendants("part").Any() == false).ToList();
                foreach (var perm in emptyPermissions)
                {
                    perm.Add(listCars);
                }
            }
