            static List<string> convertArray = new List<string>() { "START", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " " };
            static void Main(string[] args)
            {
            }
            public static int ToNumber(string subString)
            {
                int results = convertArray.IndexOf(subString);
                if (results == -1) results = 0;
                return results;
            }
            public static string ToText(int subInt)
            {
                string results = " ";
                if (subInt > 0 && subInt < convertArray.Count())
                {
                    results = convertArray[subInt];
                }
                return results;
            }
