    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    public class MyControl: UserControl
    {
        public MyControl()
        {
            ByteList = new SerializableByteList();
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public SerializableByteList ByteList { get; set; }
    }
    public class SerializableByteList
    {
        public SerializableByteList()
        {
            Bytes = new List<byte>();
        }
        public List<byte> Bytes { get; set; }
    }
