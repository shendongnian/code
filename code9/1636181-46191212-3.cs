    using System;
    abstract class Value {
        public string StringValue {
            get;
            protected set;
        }
        public static implicit operator Value(string input) {
            return new StringValue(input);
        }
    }
    class StringValue : Value {
        public StringValue(string str) {
            StringValue = str;
        }
    }
    class Xml {
        string _value;
        public Xml(string value) {
            _value = value;
        }
        public static implicit operator Xml(string input) {
            return new Xml(input.ToUpperInvariant());
        }
        public static implicit operator Value(Xml xml) {
            Value ret = xml._value;
            return ret;
        }
    }
    class Program {
        static void Main(string[] args) {
            // this works with the cast operators...
            Value v1 = (Xml)"test";
            Console.WriteLine(v1.StringValue); // "TEST"
            // ...but I would definitely go for this:
            Value v2 = sanitize("test");
        }
    }
