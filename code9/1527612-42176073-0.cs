    public class StatusTransferObject
    {
        public int DetectorId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int? DetectorModeId { get; set; }
        public int? StationModeId { get; set; }
        public decimal Status { get; set; }
    }
    var orderedObjects1 = ObjectContext.DetectorStatus.OrderBy(s => s.Status).Select(s => new StatusTransferObject
    {
        DetectorId = s.DetectorID,
        DateTime = s.DateTime,
        DetectorModeId = s.DetectorModeID,
        StationModeId = null,
        Status = s.Status
    });
    var orderedObjects2 = ObjectContext.StationStatus.OrderBy(s => s.Status).Select(s => new StatusTransferObject
    {
        DetectorId = s.DetectorID,
        DateTime = s.DateTime,
        DetectorModeId = null,
        StationModeId = s.StationModeID,
        Status = s.Status
    });
    var mergedObjects = MergeSorted(orderedObjects1, orderedObjects2, (x1, x2) => x1.Status.CompareTo(x2.Status)).ToList();
