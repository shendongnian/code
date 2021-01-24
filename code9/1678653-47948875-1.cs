    public class Bar
    {
        public int BarId { get; }
        public Bar(DataRow row)
        {
            BarId = row.Field<int>(nameof(BarId));
        }
    }
