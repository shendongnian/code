    static class Global
    {
        private static List<GridRows> _globalVar = new List<GridRows>();
        public static void ResetGridData()
        {
            _globalVar = new List<GridRows>();
        }
        public static GridRows SetRow
        {
            set { _globalVar.Add(value); }
        }
        public static List<GridRows> GetSetting { get { return _globalVar; } }
        public class GridRows
        {
            public string Cell_1 { get; set; }
            public string Cell_2 { get; set; }
            public string Cell_3 { get; set; }
            public string Cell_4 { get; set; }
        }
    }
