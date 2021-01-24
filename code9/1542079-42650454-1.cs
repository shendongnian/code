        Dictionary<int, int> _map = new Dictionary<int, int>()
        {
            /*{ cbxA, iA },*/
            /*{ cbxB, iB }*/
            /*...*/
        };
        public List<int> GetList()
        {
            var min = _map.Where(x => x.Key.Checked).Select(x => x.Value).DefaultIfEmpty(100).Min();
            return Enumerable.Range(0, Math.Min(min,100)).ToList();
        }
