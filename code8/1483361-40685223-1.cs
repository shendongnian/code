    public class TasDataView
    {
        public int nTas { get; set; }
        public string codTas { get; set; }
        public decimal nValue { get; set; }
        public bool nState { get; set; }
        public System.DateTime nDate { get; set; }
        public IEnumerable<Segments> ListSegments { get; set; }
        public IEnumerable<Tas> ListTas { get; set; }
        public Int32 selectedSegment;
    }
    @Html.DropDownListFor(x => x.selectedSegment, new SelectList(Model.ListSegments.Select(s => s.segmentCode)));
