    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                FormularData data = new FormularData() { Item1 = "aa", Item2 = "bb" };
                //Dictionary<string, string> dictionary = data;
                foreach (var item in data)
                    Console.WriteLine(item);
            
                Console.ReadLine();
            }
        }
        public class FormularData : IEnumerable<KeyValuePair<string,string>>
        {
            public string Item1 { get; set; }
            public string Item2 { get; set; }
            public static implicit operator Dictionary<string, string>(FormularData obj)
            {
                var list = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(obj.Item1))
                    list.Add("Item1", obj.Item1);
                if (!string.IsNullOrEmpty(obj.Item2))
                    list.Add("Item2", obj.Item2);
                return list;
            }
            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                return ((Dictionary<string, string>)this).GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
