    public interface IMainView
    {
        IDataGridView1 DataView1 { get; set; }
        IDataGridView2 DataView2 { get; set; }
        IDataGridView3 DataView3 { get; set; }
        void ShowOnlyDataView1();
        void ShowOnlyDataView2();
        void ShowOnlyDataView3();
        // Other methods, properties, etc...
    }
