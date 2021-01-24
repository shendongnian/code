    public static class Extensions
    {      
        public static List<string> CompareLists(this List<string> listA, List<string> listB)
        {
            List<string> results = new List<string>();
            foreach (string s in listA)
            {
                foreach (string s1 in listB)
                {
                    if (s.Equals(s1))
                    {
                        results.Add(s);
                    }
                }
            }
            return results;
        }
    }
