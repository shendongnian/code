        static void Main(string[] args)
        {
            var result = Parse(new List<string>() { "3;5;7", "qwe;3;70" });
        }
        public static List<Tuple<int, int, int>> Parse(List<string> list)
        {
            List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
            int line = 0;
            int errorCol = 0;
            try
            {
                for (line = 0; line < list.Count; line++)
                {
                    string[] curentLine = list[line].Split(';');
                    int result0, result1, result2;
                    errorCol = 1;
                    if (curentLine.Length > 0 && int.TryParse(curentLine[0], out result0))
                        errorCol = 2;
                    else
                        throw new Exception();
                    if (curentLine.Length > 1 && int.TryParse(curentLine[1], out result1))
                        errorCol = 3;
                    else
                        throw new Exception();
                    if (curentLine.Length > 2 && int.TryParse(curentLine[2], out result2))
                        result.Add(new Tuple<int, int, int>(result0, result1, result2));
                    else
                        throw new Exception();
                }
                return result;
            }
            catch
            {
                //here in braces I want to know, which element was wrong
                throw new FormatException("Wrong line " + line + " col" + errorCol);
            }
        }
