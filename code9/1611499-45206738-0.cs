    public class Coffee
    {
        private IReadOnlyList<int> info;
        public Coffee(List<int> info)
        {
            this.info = info;
        }
        public List<int> Restore()
        {
            return info.ToList();
        }
    }
