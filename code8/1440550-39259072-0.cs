    using System;
    
    namespace ConsoleApplication2
    {
        public class RowBase { }
    
        public class SpecificRow : RowBase { }
    
        public class RowListItem<TRow> : IInputSave<TRow> where TRow : RowBase { }
    
        public class SpecificRowListItem : RowListItem<SpecificRow> { }
    
        internal interface IInputSave<out TRow>
            where TRow : RowBase
        {
        }
    
        class Program
        {
            public static void Main(string[] args)
            {
                var demo = new Program();
                demo.Demo();
            }
    
            public void Demo() {
    
                var foo = new SpecificRow();
                var bar = new SpecificRowListItem();
                var baz = new RowListItem<SpecificRow>();
                string name;
    
                name = GetName(foo);
                Console.WriteLine(name);
                name = GetName(baz);
                Console.WriteLine(name);
                name = GetName(bar); 
                Console.WriteLine(name);
                name = GetName((RowListItem<SpecificRow>)bar); // this alternative invokes the second overload
                Console.WriteLine(name);
                //name = GetName<SpecificRow>(bar); 
                
                Console.ReadKey();
            }
    
            public string GetName(RowBase row)
            {
                return "oink";
            }
    
            public string GetName(IInputSave<RowBase> item)
            {
                return "nested oink";
            }
        }
    }
    
