    public class Program
    {
        // Take distinct set of random numbers in a given range
        public static List<int> GetDistinctRandomNumbers(int min, int max, int count)
        {
            // Must do error checks for if (min > max) etc...
            var rnd = new Random();
            var val = Enumerable.Range(min, max).OrderBy(x => rnd.Next());
            return val.Take(count).ToList();
        }
        // Get a substring of a string composed by extracting characters from given indices
        public static string GetStringByIndices(string str, List<int> indexes)
        {
            string result = string.Empty;
            foreach (var index in indexes)
                result += str[index];
            return result;
        }
        public static string CreateRandomString(string str1, string str2)
        {
            // Number of characters to extract from each string
            int len1 = (str1.Length < 4) ? str1.Length : 4;
            int len2 = (str2.Length < 4) ? str2.Length : 4;
            // Indices at which characters will be extracted from each string
            var str1Indexes = GetDistinctRandomNumbers(0, str1.Length, len1);
            var str2Indexes = GetDistinctRandomNumbers(0, str2.Length, len2);
            // Extracted strings
            var first = GetStringByIndices(str1, str1Indexes);
            var second = GetStringByIndices(str2, str2Indexes);
            // Potentially unique string
            return first + second;
        }
        public static void CreateUniqueList(string strToAdd, ref Dictionary<string,int> dict)
        {
            if (!dict.ContainsKey(strToAdd))
                dict.Add(strToAdd, 1);  // If not found in the dictionary, add it, with a count of 1
            else
            {
                int count;
                if (dict.TryGetValue(strToAdd, out count))
                {
                    dict.Add(strToAdd + count.ToString(), count + 1);   // If found, add a new item where NewKey = ExistingKey + Count
                    dict[strToAdd] += 1;    // Increment count of existing Key
                }
            }
        }
        public static void Main()
        {
            Dictionary<string, int> unique = new Dictionary<string, int>();
            for (int i = 0; i < 20; i++)
            {
                var str = CreateRandomString("Jennifer", "Lawrence");
                CreateUniqueList(str, ref unique);
            }
            Console.ReadLine();
        }
    }
