            if (System.IO.File.Exists("a.txt"))
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^a-\\d+\\.txt$");
                int[] numbers = System.IO.Directory.GetFiles("path", "a-*.txt").Where(x => regex.IsMatch(x)).Select(x => int.Parse(x.Split('-', '.')[1])).OrderBy(x => x).ToArray();
                for (int c = 0; c < numbers.Length; c++)
                    if (numbers[c] != c + 2)
                    {
                        CreateFile(string.Concat("a-", (c + 2).ToString(), ".txt"));
                        break;
                    }
                CreateFile(string.Concat("a-", (numbers.Length + 2).ToString(), ".txt"));
            }
            else
            {
                CreateFile("a.txt");
            }
