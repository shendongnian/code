    using System;
    class Value {
        public string StringValue {
            get;
            private set;
        }
        protected Value(string str) {
            StringValue = str;
        }
        public static implicit operator Value(string input) {
            return new Value(input);
        }
    }
    class XmlValue : Value {
        protected XmlValue(string str) : base(str) {
        }
        public static implicit operator XmlValue(string input) {
            // using "ToUpperInvariant" instead of sanitize
            return new XmlValue(input.ToUpperInvariant());
        }
    }
    class Program {
        static void Main(string[] args) {
            Value v1 = "test";
            Console.WriteLine(v1.StringValue); // "test"
            XmlValue v2 = "test";
            Console.WriteLine(v2.StringValue); // "TEST"
        }
    }
