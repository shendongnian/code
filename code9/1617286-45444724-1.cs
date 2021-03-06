    private static void CalculateAverage(List<string> lines)
        {
            char[] seperator = new char[] { ',' };
            List<int> scores = new List<int>();
            if (lines != null && lines.Count > 0)
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    string[] parts = line.Split(seperator);
                    int val;
                    if (int.TryParse(parts[1], out val))
                    {
                        scores.Add(val);
                    }
                }
            }
            double avg = scores.Average();
            int max = scores.Max();
            Console.WriteLine("Average: {0}", avg);
            Console.WriteLine("Highest Score: {0}", max);
        }
