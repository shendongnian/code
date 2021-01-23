    FieldCount abn, abn2;
    public class FieldCount
    {
        public byte Count { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
        public FieldCount Yk { get; set; }
    }
    public ObservableCollection<Field> a;
