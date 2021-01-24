    public class TermsTable 
    {
        private readonly Dictionary<string, IndexByCommodityId> _index;
        public TermsTable(IEnumerable<TermsCommodityModel> list)
        {
            _index = list
                .GroupBy(tcm => tcm.name)
                .ToDictionary(
                    tcmGroup => tcmGroup.Key,
                    tcmGroup => new IndexByCommodityId(tcmGroup));
        }
        public IndexByCommodityId this[string name] => _index[name];
    }
    public class IndexByCommodityId
    {
        private readonly Dictionary<int, IndexByYear> _index;
        public IndexByCommodityId(IEnumerable<TermsCommodityModel> list)
        {
            _index = list.ToDictionary(
                keySelector: tcm => tcm.commodity_id,
                elementSelector: tcm => new IndexByYear());
        }
        public IndexByYear this[int commodityId] => _index[commodityId];
    }
    public class IndexByYear
    {
        private static readonly int _nowYear = DateTime.Now.Year;
        private readonly Dictionary<int, IndexByMonth> _index;
        public IndexByYear()
        {
            _index = Enumerable
                .Range(2008, _nowYear - 2008 + 1)
                .ToDictionary(
                    keySelector: year => year,
                    elementSelector: year => new IndexByMonth());
        }
        public IndexByMonth this[int year] => _index[year];
    }
    public class IndexByMonth
    {
        private readonly Dictionary<int, int> _index;
        public IndexByMonth()
        {
            _index = Enumerable.Range(1, 12).ToDictionary(month => month, month => 0);
        }
        public int this[int month]
        {
            get => _index[month];
            set => _index[month] = value;
        }
    }
