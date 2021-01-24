    public class Coffee
    {
        private IReadOnlyList<int> info;
        public Coffee(List<int> info)
        {
            this.info = info; // You can view original collection in readonly mode
        }
        public List<int> Restore()
        {
            return info.ToList(); // Makes a copy of original list
        }
    }
