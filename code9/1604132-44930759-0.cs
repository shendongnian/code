    public class RowData {
        public string Label { get; set; }
        public string Reason { get; set; }
        public int AbsNumber { get; set; }
        public decimal? AbsenceHours { get; set; }
    }
    public class AbsByReason {
        public decimal Aut { get; set; }
        public decimal CM { get; set; }
        public string Label { get; set; }
        public object NoAut { get; set; }
    }
    public static IEnumerable<AbsByReason> TransformData(List<RowData> totalbeAbsencesDepartmentByReason) {
        return totalbeAbsencesDepartmentByReason
                    .GroupBy(row => row.Label)
                    .Select(XFormLabelGroupToAbsByReason);
    }
    private static AbsByReason XFormLabelGroupToAbsByReason(IEnumerable<RowData> labelGroup) {
        var reason = new AbsByReason();
        foreach (var rowData in labelGroup) {
            if (rowData.Reason == "AUT")
                reason.Aut = rowData.AbsenceHours ?? 0;
            else if (rowData.Reason == "NOAUT")
                reason.NoAut = rowData.AbsenceHours ?? 0;
            else if (rowData.Reason == "CM")
                reason.CM = rowData.AbsenceHours ?? 0;
        }
        return reason;
    }
