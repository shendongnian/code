    public partial class PartList
    {
        [XmlIgnore]
		public List<string> Name { get; } = new List<string>();
        [XmlIgnore]
		public List<string> Data { get; } = new List<string>();
        [XmlIgnore]
        public List<string> OtherData { get; } = new List<string>();
        [System.Xml.Serialization.XmlElementAttribute("Name", typeof(Name), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("Data", typeof(Data), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("OtherData", typeof(OtherData), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ValueWrapper<string>[] Values
        {
            get
            {
                var list = new List<ValueWrapper<string>>();
                for (int i = 0, count = Math.Max(Name.Count, Math.Max(Data.Count, OtherData.Count)); i < count; i++)
                {
                    if (i < Name.Count)
                        list.Add(new Name { Value = Name[i] });
                    if (i < Data.Count)
                        list.Add(new Data { Value = Data[i] });
                    if (i < OtherData.Count)
                        list.Add(new OtherData { Value = OtherData[i] });
                }
                return list.ToArray();
            }
            set
            {
                if (value == null)
                    return;
                Name.AddRange(value.OfType<Name>().Select(v => v.Value));
                Data.AddRange(value.OfType<Data>().Select(v => v.Value));
                OtherData.AddRange(value.OfType<OtherData>().Select(v => v.Value));
            }
        }
    }
    public class Name : ValueWrapper<string> { }
    public class Data : ValueWrapper<string> { }
    public class OtherData : ValueWrapper<string> { }
    public abstract class ValueWrapper<T> : ValueWrapper where T : IConvertible
    {
        public override object GetValue() => Value; 
		
        [XmlText]
        public T Value { get; set; }
    }
    public abstract class ValueWrapper
    {
        public abstract object GetValue();
    }
