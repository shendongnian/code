    string one = "this is string one";
            string two = "this is string one or two";
            char[] oneChar = one.ToCharArray();
            char[] twoChar = two.ToCharArray();
            int index = 0;
            List<char> Diff = new List<char>();
            if (oneChar.Length > twoChar.Length)
            {
                foreach (char item in twoChar)
                {
                    if (item != oneChar[index])
                        Diff.Add(item);
                    index++;
                }
                for (int i = index; i < oneChar.Length; i++)
                {
                    Diff.Add(oneChar[i]);
                }
            }
            else if (oneChar.Length < twoChar.Length)
            {
                foreach (char item in oneChar)
                {
                    if (item != twoChar[index])
                        Diff.Add(twoChar[index]);
                    index++;
                }
                for (int i = index; i < twoChar.Length; i++)
                {
                    Diff.Add(twoChar[i]);
                }
            }
            else//equal length
            {
                foreach (char item in twoChar)
                {
                    if (item != oneChar[index])
                        Diff.Add(item);
                }
            }
            Console.WriteLine(Diff.ToArray());//" or two"
