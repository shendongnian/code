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
                    var startNumber = int.Parse(range[0]);
                    var endNumber = int.Parse(range[1]);
                    for (var i = startNumber; i < endNumber; i++)
                    {
                        _MissingInt.Add(i);
                    }
                }
                else
                {
                    _MissingInt.Add(int.Parse(line));
                }
            }
