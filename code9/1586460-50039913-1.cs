    public enum StateEnum {
          Ok = 1,
          Fail = 2
    }
    public partial class Foo
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public StateEnum State
        {
            get => (StateEnum)StateId;
            set => StateId = (int)value;
        }
    }
