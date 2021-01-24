        public static class Extensions
    {      
        public static bool CompareLists(this List<string> listA, List<string> listB)
        {
            foreach (string s in listA)
            {
                foreach (string s1 in listB)
                {
                    if (s.Equals(s1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
