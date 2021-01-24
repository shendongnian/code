    using System;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        internal class Program
        {
        
        private const BindingFlags BindingFlags =
                    System.Reflection.BindingFlags.GetProperty
                    | System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance;
        private static void Main(string[] args)
        {
            var obj = new MessageEntry();
            var props = typeof (MessageEntry).GetProperties(BindingFlags);
            foreach (var p in props)
            {
                var value = p.GetValue(obj);
                if (value == null)
                    continue;
                if (typeof (Tuple<,>) == value.GetType())
                    continue;
                var item1Type = value.GetType().GetProperty("Item1", BindingFlags);
                if (item1Type == null)
                    continue;
                var item1Value = item1Type.GetValue(value);
                //Here you can get bool value
                Console.WriteLine(item1Value);
            }
            Console.ReadLine();
        }
    }
    public class MessageEntry
    {
        public MessageEntry()
        {
            MessageId = new Tuple<bool, int>(true, 1);
            MessageDate = new Tuple<bool, DateTime>(false, DateTime.Now);
            Subject = new Tuple<bool, string>(true, "Hello, World!");
        }
        // Pay attention, I changed this place, so as not to duplicate the reflection code. 
        // For properties and field, it is similar, but still disconnects
        public Tuple<bool, int> MessageId { get; internal set; }
        public Tuple<bool, DateTime> MessageDate { get; internal set; }
        public Tuple<bool, String> Subject { get; internal set; }
        public Tuple<bool, String> EmailFrom { get; internal set; }
        public Tuple<bool, String> EmailTo { get; internal set; }
        public Tuple<bool, String> EmailCC { get; internal set; }
        public Tuple<bool, String> EmailBCC { get; internal set; }
        public Tuple<bool, String> EmailDateSent { get; internal set; }
        public Tuple<bool, String> BodyHTML { get; internal set; }
        }
    }
