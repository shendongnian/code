    class Program {
        static void Main(string[] args) {
            var readMessageType = typeof(ReadMessage<>).MakeGenericType(
                System.Reflection.Assembly.GetExecutingAssembly().GetTypes().First(p => p.Name == "MyMessageBase01")
            );
            var constructor = readMessageType.GetConstructor(Type.EmptyTypes);
            var readMessage = constructor.Invoke(null);
            Console.WriteLine(readMessage.ToString());
        }
    }
    public class MyMessageBase01 {
    }
    public class ReadMessage<T> {
        public override string ToString() {
            return "I'm a ReadMessage Of Type " + typeof(T).FullName;
        }
    }
