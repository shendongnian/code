    public class PointDataClone
    {
        public int DataId { get; set; }
        [DontShowMe]
        public string UniqueKey { get; set; }
        public int Count { get; set; }
        [DontShowMe]
        public List<PointToPointData> PointToPointData { get; set; }
    }
