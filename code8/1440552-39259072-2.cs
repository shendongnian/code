      using System;
    
    namespace CoVariance
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
            public static void Main(string[] args){
    
                var foo = new SpecificRow();
                var bar = new SpecificRowListItem();
                var baz = new RowListItem<SpecificRow>();
                string name;
    
                name = GetName(foo);
                Console.WriteLine(name); //oink
                name = GetName(baz);
                Console.WriteLine(name); //nested oink
                name = GetName(bar);
                Console.WriteLine(name); //nested oink
                name = GetName((RowListItem<SpecificRow>)bar);
                Console.WriteLine(name); //nested oink
                //name = GetName<SpecificRow>(bar); 
                
                Console.ReadKey();
            }
    
            public static string GetName(RowBase row)
            {
                return "oink";
            }
    
            public static string GetName(IInputSave<RowBase> item)
            {
                return "nested oink";
            }
        }
    }
    
