    [Serializable]    
    public readonly struct MyStruct : ISerializable, IXmlSerializable
    {        
        private readonly double number;
        public MyStruct(double number)
            => this.number = number;
        private MyStruct(SerializationInfo info, StreamingContext context)
            => this.number = info.GetDouble(nameof(this.number));
        XmlSchema IXmlSerializable.GetSchema() {
            return null;
        }
        unsafe void IXmlSerializable.ReadXml(XmlReader reader) {
            if (reader.Read()) {
                var value = double.Parse(reader.Value, CultureInfo.InvariantCulture);
                fixed (MyStruct* t = &this) {
                    *t = new MyStruct(value);
                }
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer) {
            writer.WriteString(this.number.ToString(CultureInfo.InvariantCulture));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue(nameof(number), this.number);
        }
    }
