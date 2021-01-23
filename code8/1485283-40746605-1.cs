        static void Main(string[] args)
        {
            Dictionary<int, string> fdr1Dict = FilesToDictionary(Directory.GetFiles("path1"));
            Dictionary<int, string> fdr2Dict = FilesToDictionary(Directory.GetFiles("path2"));
            var unique_f1 = fdr1Dict.Where(f1 => !fdr2Dict.ContainsKey(f1.Key)).ToArray();
            var unique_f2 = fdr2Dict.Where(f2 => !fdr1Dict.ContainsKey(f2.Key)).ToArray();
            int f1_size = unique_f1.Length;
            int f2_size = unique_f2.Length;
            int list_length = 0;
            if (f1_size > f2_size)
            {
                list_length = f1_size;
                Array.Resize(ref unique_f2, list_length);
            }
            else
            {
                list_length = f2_size;
                Array.Resize(ref unique_f1, list_length);
            }
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine(string.Format("{0,-30}{1,-30}", "Unique in fdr1", "Unique in fdr2"));
                for (int i = 0; i < list_length; i++)
                {
                    writer.WriteLine(string.Format("{0,-30}{1,-30}", unique_f1[i].Value, unique_f2[i].Value));
                }
            }
        }
        static Dictionary<int, string> FilesToDictionary(string[] filenames)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < filenames.Length; i++)
            {
                int glNumber;
                string filename = Path.GetFileName(filenames[i]);
                string number = Regex.Match(filename, @"\d+").ToString();
                if (int.TryParse(number, out glNumber))
                    dict.Add(glNumber, filename);
            }
            return dict;
        }
