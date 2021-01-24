    public class MyEntity : TableEntity
    {
        public int MyPropertyInt { get; set; }
        [IgnoreProperty]
        public byte MyProperty
        {
            get
            {
                return (byte)this.MyPropertyInt;
            }
            set
            {
                this.MyPropertyInt = value;
            }
        }
    }
