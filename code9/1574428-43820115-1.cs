            var fileNames = Directory.GetFiles(targetDirectory);
            var numberList = new List<int>();
            int number;
            foreach (var name in fileNames) {
                Match m = Regex.Match(name, "\\d+"); // this gets the number at beginning of filename
                var isNumber = Int32.TryParse(m.ToString(), out number);
                if(isNumber)
                    numberList.Add(number);
            }
            var highest = numberList.OrderByDescending(x => x).FirstOrDefault();
