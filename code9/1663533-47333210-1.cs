    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var test = new List<MessageEntry>();
    
                var result = test
                    .Where(entry => entry.IsAllTuplePropertiesIsTrue())
                    .Aggregate(
                        string.Empty, 
                        (s, entry) => s + $"value is {entry.IsAllTuplePropertiesIsTrue()}"
                        );
    
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    
        public static class MessageEntryExtension
        {
            private const BindingFlags BindingFlags = 
                System.Reflection.BindingFlags.GetProperty
                | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.Instance;
    
            /// <summary>
            /// Method check all <see cref="Tuple" /> properties 
            /// in instance of <see cref="MessageEntry" /> class.
            /// </summary>
            /// <param name="messageEntry"></param>
            /// <returns>If one of several Tuple.Item1 value is not bool false not equal 
            /// false - return false. Any way - true</returns>
            public static bool IsAllTuplePropertiesIsTrue(this MessageEntry messageEntry)
            {
                var props = typeof (MessageEntry).GetProperties(BindingFlags);
    
                foreach (var value in props.Select(p => p.GetValue(messageEntry)))
                {
                    if (value == null)
                        return false;
    
                    if (typeof (Tuple<,>) == value.GetType())
                        return false;
    
                    var item1Type = value.GetType().GetProperty("Item1", BindingFlags);
                    var item1Value = item1Type?.GetValue(value);
    
                    if (!(item1Value is bool))
                        return false;
    
                    if (!(bool) item1Value)
                        return false;
                }
    
                return true;
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
    
            // Pay attention, I changed this place, 
            // so as not to duplicate the reflection code. 
            // For properties and field, it is similar, but still disconnects
            public Tuple<bool, int> MessageId { get; internal set; }
    
            public Tuple<bool, DateTime> MessageDate { get; internal set; }
            public Tuple<bool, string> Subject { get; internal set; }
            public Tuple<bool, string> EmailFrom { get; internal set; }
            public Tuple<bool, string> EmailTo { get; internal set; }
            public Tuple<bool, string> EmailCC { get; internal set; }
            public Tuple<bool, string> EmailBCC { get; internal set; }
            public Tuple<bool, string> EmailDateSent { get; internal set; }
            public Tuple<bool, string> BodyHTML { get; internal set; }
        }
    }
