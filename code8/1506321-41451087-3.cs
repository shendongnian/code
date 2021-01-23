    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Channels;
    using System.Text.RegularExpressions;
    using System.Xml;
    
    namespace MyProgram
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // real-world variables, keep them typed as base Message
                // to be able to silently replace them with different objects
                Message original1;
                Message original2;
    
                // let's construct some one-time readable messages
                {
                    original1 = new TheMessage("dad", "dog");
                    original2 = new TheMessage("dad", "dog");
                }
    
    
                // test1 - can't read twice
    
                Console.WriteLine("test0A:" + original1.GetReaderAtBodyContents().ReadOuterXml());
                // Console.WriteLine("test0B:" + original1.GetReaderAtBodyContents().ReadOuterXml()); // fail: InvalidOperationException - it was already read
    
    
                // test2 - can read ONCE with Reader's help, but the message is replaced and is usable again
    
                var backup1 = original2;
                using (var rd1 = new ReaderOnce(ref original2))
                {
                    Console.WriteLine("is message replaced after opening Reader:" + (original2 != backup1));
    
                    Console.WriteLine("test1A:" + rd1.ReadBodyXml());
                    // Console.WriteLine("test1B:" + rd1.ReadBodyXml()); // fail: InvalidOperationException - it was already read
                }
    
    
                // test3 - can read MANY TIMES with ReaderMany's help
                // also note we use 'original2' again, which was already used above, so in fact ReaderOnce really works as well
    
                var backup2 = original2;
                using (var rd1 = new ReaderMany(ref original2))
                {
                    Console.WriteLine("is message replaced after opening Reader:" + (original2 != backup2));
    
                    Console.WriteLine("test2A:" + rd1.ReadBodyXml());
                    Console.WriteLine("test2B:" + rd1.ReadBodyXml()); // ok
                }
    
    
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
    
    // solution1
    public class ReaderOnce : IDisposable
    {
        private Message localCopy;
    
        public ReaderOnce(ref Message src)
        {
            // create a WCF MessageBuffer to assist in copying messages
            // btw. I suppose you should set some sane limit instead of that below
            using (var tempBuffer = src.CreateBufferedCopy(int.MaxValue))
            {
                src = tempBuffer.CreateMessage(); // FIRST copy for outer use
                localCopy = tempBuffer.CreateMessage(); // SECOND copy for internal use in the Reader
            }
        }
    
        public void Dispose() { Close(); }
    
        public void Close()
        {
            localCopy.Close(); // but that does NOT affect FIRST copy sent to outer scope outside reader
            Console.WriteLine("reader closed");
        }
    
        public string ReadBodyXml() // careful: that's again ONE TIME readable
        {
            return localCopy.GetReaderAtBodyContents().ReadOuterXml();
        }
    }
    
    // solution2
    public class ReaderMany : IDisposable
    {
        private MessageBuffer localBuffer;
    
        public ReaderMany(ref Message src)
        {
            localBuffer = src.CreateBufferedCopy(int.MaxValue);
            src = localBuffer.CreateMessage(); // FIRST copy for outer use
        }
    
        public void Dispose() { Close(); }
    
        public void Close()
        {
            localBuffer.Close();
            Console.WriteLine("reader closed");
        }
    
        public string ReadBodyXml() // this is readable multiple times
        {
            using (var tmp = localBuffer.CreateMessage())
                return tmp.GetReaderAtBodyContents().ReadOuterXml();
        }
    }
    
    
    // let's fake some Message type to have something to test the Reader on
    public class TheMessage : Message
    {
        public override MessageHeaders Headers => _mh;
    
        public override MessageProperties Properties => _mp;
    
        public override MessageVersion Version => _mv;
    
        private MessageHeaders _mh;
        private MessageProperties _mp;
        private MessageVersion _mv;
    
        private string data1;
        private string data2;
    
        // btw. below: surprise! XmlDictionaryWriter is in "System.Runtime.Serialization", not in "System.Xml"
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("foo");
            writer.WriteAttributeString("data1", data1);
            writer.WriteAttributeString("data2", data2);
            writer.WriteEndElement();
        }
    
        public TheMessage(string data1, string data2)
        {
            // remember, this class is just an example, you will work on your own messages you already have
            _mv = MessageVersion.Soap12;
            _mh = new MessageHeaders(_mv);
            _mp = new MessageProperties();
    
            // below: yeah, that's super-naive and wrong, but that's an example
            this.data1 = data1;
            this.data2 = data2;
        }
    }
