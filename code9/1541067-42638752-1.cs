    private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        {
            foreach(Dictionary<string,string> item in someJobs)
            {
                foreach (KeyValuePair<string, string> pair in item) {
                    Console.WriteLine(string.Format("{0} {1}", pair.Key, pair.Value));
                }
            }
            //Console.WriteLine("printJobs is not implemented yet");
        }
