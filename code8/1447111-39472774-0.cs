    public class MyComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            return first.Remove(0, first.IndexOf('_'))
                .CompareTo(second.Remove(0, second.IndexOf('_'));
        }
    }
