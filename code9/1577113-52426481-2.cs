    using System.Runtime.Serialization;
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.XLANGs.BaseTypes;
    
    namespace Yournamespace.Components
    {
        public abstract class BaseFormatter : IFormatter
        {
            public virtual SerializationBinder Binder
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
    
            public virtual StreamingContext Context
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
    
            public virtual ISurrogateSelector SurrogateSelector
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
    
            public abstract void Serialize(Stream stm, object obj);
            public abstract object Deserialize(Stream stm);
        }
    
        public class RawStringFormatter : BaseFormatter
        {
            public override void Serialize(Stream s, object o)
            {
                RawString rs = (RawString)o;
                byte[] ba = rs.ToByteArray();
                s.Write(ba, 0, ba.Length);
            }
    
            public override object Deserialize(Stream stm)
            {
                StreamReader sr = new StreamReader(stm, true);
                string s = sr.ReadToEnd();
                return new RawString(s);
            }
        }
    
        [CustomFormatter(typeof(RawStringFormatter))]
        [Serializable]
        public class RawString
        {
            [XmlIgnore]
            string _val;
    
            public RawString(string s)
            {
                if (null == s)
                    throw new ArgumentNullException();
                _val = s;
            }
    
            public RawString()
            {
            }
    
            public byte[] ToByteArray()
            {
                return Encoding.UTF8.GetBytes(_val);
            }
    
            public override string ToString()
            {
                return _val;
            }
        }
    }
