    class CakeInfo
    {
        List<Tuple<int, int>> CakesBakedByWeek { get; private set; }
        List<Tuple<int, int>> CakesSoldByWeek { get; private set; }
        List<Tuple<int, int>> CakesBurntByWeek { get; private set; }
        public CakeInfo(
            IEnumerable<Tuple<int, int>> baked, 
            IEnumerable<Tuple<int, int>> sold, 
            IEnumerable<Tuple<int, int>> burnt
        )
        {
            CakesBakedByWeek = baked.ToList();
            CakesSolByWeek = sold.ToList();
            CakesBurntByWeek = burnt.ToList();
        } 
    }
