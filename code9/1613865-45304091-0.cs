    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("First:");
            MyClass c = new MyClass();
            c.Set(new {Property1="1", Property2="2", Property4="4"});
            Console.WriteLine(c);
            Console.WriteLine("Second:");
            c.SetWithReflection(new {Property1="11",Property2="22", Property4="44"});
            Console.WriteLine(c);
            
        }
    }
    public class MyClass{
        public void Set(dynamic d){
            try{ Property1=d.Property1;}catch{}
            try{ Property2=d.Property2;}catch{}
            try{ Property3=d.Property3;}catch{}
        }
        
        public string Property1{get;set;}
        public string Property2{get;set;}
        public string Property3{get;set;}
        public override string ToString(){
            return string.Format(@"Property1: {0}
    Property2: {1}
    Property3: {2}", Property1,Property2,Property3);
        }                
    }
    public static class Extensions{
        public static void SetWithReflection<T>(this T owner, dynamic d){
            var dynamicProps = d.GetType().GetProperties();
            foreach(PropertyInfo p in dynamicProps){
                var prop = typeof(T).GetProperty(p.Name);
                if(prop!=null){
                    try{ prop.SetValue(owner, p.GetValue(d)); } catch{}
                }
            }
        }
    } 
