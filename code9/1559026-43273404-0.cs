    public abstract class Command
    {
        // define a public property for each element you want to query
        public byte Data { get; }
        public Command(byte data)
        {
            Data = data;
        }
    }
    public class Command1 : Command
    {
        // Require each subclass to define a static "prototype" instance,
        // calling the constructor with default values for any args
        public static Command Prototype = new Command1();
        public Command1() : base(0x12)
        {
        }
    }
    [TestFixture]
    public class ReflectionTest
    {
        [Test]
        public static void ListPrototypes()
        {
            // find all loaded subclasses of Command
            var subclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(Command))
                select type;
            foreach (var subclass in subclasses)
            {
                // get the prototype instance of each class
                var prototype =
                    subclass.GetField("Prototype", BindingFlags.Public | BindingFlags.Static)?.GetValue(null) as Command;
                if (prototype != null)
                {
                    // emit the data from the prototype
                    Console.WriteLine($"{subclass.Name}, Data={prototype.Data}");
                }
            }
        }
    }
