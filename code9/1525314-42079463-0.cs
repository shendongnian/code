            List<string> csvfile1Text = System.IO.File.ReadAllLines("file1.csv").ToList();
            List<string> csvfile2Text = System.IO.File.ReadAllLines("file2.csv").ToList();
            Dictionary<string, double> csv1Formatted = new Dictionary<string, double>();
            Dictionary<string, double> csv2Formatted = new Dictionary<string, double>();
            Dictionary<string, double> csv3Formatted = new Dictionary<string, double>();
            foreach (string line in csvfile1Text)
            {
              var temp=  line.Split(',');
                csv1Formatted.Add(temp[0], Double.Parse(temp[1]));
            }
            foreach (string line in csvfile2Text)
            {
                var temp = line.Split(',');
                csv2Formatted.Add(temp[0], Double.Parse(temp[1]));
            }
            //operation 1
            var penultimate = csv1Formatted["1974-01-03"];
            var corrsponding = csv2Formatted["1974-01-03"];
            var difference = penultimate - corrsponding;
            //operation 2
            var start = csv2Formatted["1974-01-03"];
            var end = csv2Formatted["1974-01-09"];
            var intermediate = csv2Formatted.Keys.SkipWhile((element => element != "1974-01-03")).ToList();
            Dictionary<string, double> newCSV2 = new Dictionary<string, double>();
            foreach (string element in intermediate)
            {
               var found = csv2Formatted[element];
               found = found + difference;
                newCSV2.Add(element, found);
            }
            //operation 3
            intermediate = csv1Formatted.Keys.TakeWhile((element => element != "1975-01-03")).ToList();
            foreach (string element in intermediate)
            {
                var found = csv1Formatted[element];
                csv3Formatted.Add(element, found);
            }
            foreach (KeyValuePair<string,double> kvp in newCSV2)
            {
                csv3Formatted.Add(kvp.Key,kvp.Value);
            }
            //writing CSV3
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string,double> kvp in csv3Formatted)
            {
                sb.AppendLine(kvp.Key + "," + kvp.Value);
            }
            System.IO.File.WriteAllText("C:\\csv3.csv", sb.ToString());
