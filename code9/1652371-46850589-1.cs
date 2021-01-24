    using MongoDB.Bson.IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using MongoDB.Bson;
    
    namespace Fishing.MongoDB.Serializers
    {
        public class JsonWriterMine : BsonWriter
        {
    
            // private fields
            private TextWriter _textWriter;
            private JsonWriterSettings _jsonWriterSettings; // same value as in base class just declared as derived class
            private InternalJsonWriterContext _context;
    
            // constructors
            /// <summary>
            /// Initializes a new instance of the JsonWriter class.
            /// </summary>
            /// <param name="writer">A TextWriter.</param>
            public JsonWriterMine(TextWriter writer)
                : this(writer, JsonWriterSettings.Defaults)
            {
            }
    
            /// <summary>
            /// Initializes a new instance of the JsonWriter class.
            /// </summary>
            /// <param name="writer">A TextWriter.</param>
            /// <param name="settings">Optional JsonWriter settings.</param>
            public JsonWriterMine(TextWriter writer, JsonWriterSettings settings)
                : base(settings)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }
    
                _textWriter = writer;
                _jsonWriterSettings = settings; // already frozen by base class
                _context = new InternalJsonWriterContext(null, ContextType.TopLevel, "");
                State = BsonWriterState.Initial;
            }
    
     /// <summary>
        /// Writes a BSON DateTime to the writer.
        /// </summary>
        /// <param name="value">The number of milliseconds since the Unix epoch.</param>
        public override void WriteDateTime(long value)
        {
            if (Disposed) { throw new ObjectDisposedException("JsonWriter"); }
            if (State != BsonWriterState.Value && State != BsonWriterState.Initial)
            {
                ThrowInvalidState("WriteDateTime", BsonWriterState.Value, BsonWriterState.Initial);
            }
            WriteNameHelper(Name);
            switch (_jsonWriterSettings.OutputMode)
            {
                case JsonOutputMode.Strict:
                    var utcDateTimeFirst = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(value);
                    _textWriter.Write($"\"{utcDateTimeFirst.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ")}\"");
                    break;
                case JsonOutputMode.Shell:
                default:
                    // use ISODate for values that fall within .NET's DateTime range, and "new Date" for all others
                    if (value >= BsonConstants.DateTimeMinValueMillisecondsSinceEpoch &&
                        value <= BsonConstants.DateTimeMaxValueMillisecondsSinceEpoch)
                    {
                        var utcDateTime = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(value);
                        _textWriter.Write("ISODate(\"{0}\")", utcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ"));
                    }
                    else
                    {
                        _textWriter.Write("new Date({0})", value);
                    }
                    break;
            }
            State = GetNextState();
        }
       
        }
    }
