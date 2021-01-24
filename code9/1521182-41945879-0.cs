            //references
            using System.IO;
            using System.Text.RegularExpressions;
            //code that goes in the method
            List<Part> parts = new List<Part>();
            foreach (string line in File.ReadAllLines(@"~App_Data/file.text"))
            {
                str.Add(new Part()
                {
                    PartName = line.Split('"')[1],
                    PartId = Convert.ToInt32(Regex.Match(line, @"\d+").Value)
                });
            }
