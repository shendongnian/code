    namespace Tester
    {
        class Program
        {
            static void Main(string[] args)
            {
                var item = new PlayerComponent() {Name = "PlayerOne"};
                var item2 = item.CloneComponent();
    
                Console.ReadLine();
            }
        }
    
    
        public static class Extensions
        {
            public static TComponent CloneComponent<TComponent>(this TComponent source) where TComponent : Component, new()
            {
                TComponent clone = new TComponent(); //Create the new instance
    
                //Clone the source code here        
                Console.WriteLine($"Source: {source.GetType()}, clone: {clone.GetType()}");
    
                return clone;
            }
        }
    
        public class Component
        {
        }
    
        public class PlayerComponent : Component
        {
            public string Name { get; set; } = "Test";
        }
    }
