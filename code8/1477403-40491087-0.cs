        [Flags]
        public enum Sections
        {
            Test1 = 0,
            Test2 = 1,
            Test3 = 2,
            Test4 = 4,
        }
        public static List<Sections> getSectionsFromFlags(Sections flags)
        {
            var returnVal = new List<Sections>();
            foreach (Sections item in Enum.GetValues(typeof(Sections)))
            {
                if ((int)(flags & item) > 0)
                    returnVal.Add(item);
            }
            return returnVal;
        }
