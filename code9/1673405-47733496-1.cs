        static void Main()
        {
            using (var reader = new StreamReader(@"file"))
            {
                int lineNumber = 4;
                bool streamEnded = false;
                List<string> list = new List<string>();
                while (!streamEnded)
                {
                    var line = ReadSpecificLine(reader, lineNumber,out streamEnded);
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var values = line.Split(',');
                    list.Add(values[0]);
                }
            }
        }
        public static string ReadSpecificLine(StreamReader sr, int lineNumber,out bool streamEnded)
        {
            streamEnded = false;
            for (int i = 1; i < lineNumber; i++)
            {
                if (sr.EndOfStream)
                {
                    streamEnded = true;
                    return "";
                }
                sr.ReadLine();
            }
            if (sr.EndOfStream)
            {
                streamEnded = true;
                return "";
            }
            return sr.ReadLine();
        }
