    if (string.IsNullOrEmpty(fileName.Text)) return;
            var _MissingInt = new List<int>();
            var lines = File.ReadAllLines(fileName.Text);
            foreach (var line in lines)
            {
                if(string.IsNullOrEmpty(line)) 
                    continue;
                if (line.Contains("-"))
                {
                    var range = line.Split('-');
                    int startNumber;
                    int endNumber;
                    if(int.TryParse(range[0], out startNumber) && int.TryParse(range[1]), out endNumber)
                       for (var i = startNumber; i < endNumber; i++)
                       {
                           _MissingInt.Add(i);
                       }
                }
                else
                {
                     int num;
                     if(int.TryParse(line, out num))
                        _MissingInt.Add(num);
                }
            }
