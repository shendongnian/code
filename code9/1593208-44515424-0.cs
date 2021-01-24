        public List<person> ReadPersons(string path)
        {
            List<person> list = new List<person>();
            var lines = File.ReadAllLines(path);
            
            foreach (var line in lines)
            {
                // You can use different method to convert lien to person
                var parts = line.Split(' ');
                list.Add(new person { name = parts[0], gender = parts[1], city = parts[2], age = int.Parse(parts[3]) });
            }
            return list;
        }
