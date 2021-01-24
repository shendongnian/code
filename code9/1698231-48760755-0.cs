    gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
    gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
    // ...
    void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
        ColumnView view = ((ColumnView)sender);
        if(e.IsGetData && e.Column == gridColumn3) 
            e.Value = DateTime.Now.Day - ((EventObj)e.Row).StartDate.Day;
    }
    // ...
    public enum Status { 
        Unknown, Ok 
    }
    public class EventObj {
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
    }
