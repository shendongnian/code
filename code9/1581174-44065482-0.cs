            [WebMethod]
        public List<string> getIdentifiants() {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            lock (this) {
                using (var fs = File.OpenRead(@"C:\Users\stag01\Desktop\identifiants.csv"))
                using (var reader = new StreamReader(fs)) {
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        listA.Add(values[0]);
                        listB.Add(values[1]);
                    }
                } 
            } 
            return listA;
        }
