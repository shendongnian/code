    class Program {
        static void Main(string[] args) {
            var method = typeof(SomeClass).GetMethod("ReadMessage");
            var readMessage = method.MakeGenericMethod(System.Reflection.Assembly.GetExecutingAssembly().GetTypes().First(p => p.Name == "MyMessageBase01"));
            var o = new SomeClass();
            Console.WriteLine(readMessage.Invoke(o, null));
        }        
    }
    public class SomeClass {
        public string ReadMessage<T>() {
            return typeof(T).FullName;
        }
    }
    public class MyMessageBase01 {
    }
