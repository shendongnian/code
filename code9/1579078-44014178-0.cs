    public partial class EventData : ISpecificRecord
    {
        public static Schema _SCHEMA = Avro.Schema.Parse(@"{""type"":""record"",""name"":""EventData"",""namespace"":""Microsoft.ServiceBus.Messaging"",""fields"":[{""name"":""SequenceNumber"",""type"":""long""},{""name"":""Offset"",""type"":""string""},{""name"":""EnqueuedTimeUtc"",""type"":""string""},{""name"":""SystemProperties"",""type"":{""type"":""map"",""values"":[""long"",""double"",""string"",""bytes""]}},{""name"":""Properties"",""type"":{""type"":""map"",""values"":[""long"",""double"",""string"",""bytes"",""null""]}},{""name"":""Body"",""type"":[""null"",""bytes""]}]}");
        private long _SequenceNumber;
        private string _Offset;
        private string _EnqueuedTimeUtc;
        private IDictionary<string, System.Object> _SystemProperties;
        private IDictionary<string, System.Object> _Properties;
        private byte[] _Body;
        public virtual Schema Schema
        {
            get
            {
                return EventData._SCHEMA;
            }
        }
        public long SequenceNumber
        {
            get
            {
                return this._SequenceNumber;
            }
            set
            {
                this._SequenceNumber = value;
            }
        }
        public string Offset
        {
            get
            {
                return this._Offset;
            }
            set
            {
                this._Offset = value;
            }
        }
        public string EnqueuedTimeUtc
        {
            get
            {
                return this._EnqueuedTimeUtc;
            }
            set
            {
                this._EnqueuedTimeUtc = value;
            }
        }
        public IDictionary<string, System.Object> SystemProperties
        {
            get
            {
                return this._SystemProperties;
            }
            set
            {
                this._SystemProperties = value;
            }
        }
        public IDictionary<string, System.Object> Properties
        {
            get
            {
                return this._Properties;
            }
            set
            {
                this._Properties = value;
            }
        }
        public byte[] Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }
        }
        public virtual object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.SequenceNumber;
                case 1: return this.Offset;
                case 2: return this.EnqueuedTimeUtc;
                case 3: return this.SystemProperties;
                case 4: return this.Properties;
                case 5: return this.Body;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }
        public virtual void Put(int fieldPos, object fieldValue)
        {
            switch (fieldPos)
            {
                case 0: this.SequenceNumber = (System.Int64)fieldValue; break;
                case 1: this.Offset = (System.String)fieldValue; break;
                case 2: this.EnqueuedTimeUtc = (System.String)fieldValue; break;
                case 3: this.SystemProperties = (IDictionary<string, System.Object>)fieldValue; break;
                case 4: this.Properties = (IDictionary<string, System.Object>)fieldValue; break;
                case 5: this.Body = (System.Byte[])fieldValue; break;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
            };
        }
    }
}
