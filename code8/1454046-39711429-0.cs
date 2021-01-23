    class Program
    {
        static void Main(string[] args)
        {
            int version = 0;
            if (int.TryParse(Console.ReadLine(), out version))
            {
                IApplication application = new ApplicationProxy(version);
                Console.WriteLine("Version: {0}", application.Version);
            }
        }
    }
    /// <summary>
    /// A copy of IApplication that is local to your program that holds the shared members.
    /// This is what the rest of your program will likely use.
    /// </summary>
    public interface IApplication
    {
        string Version { get; }
    }
    public class ApplicationProxy : IApplication
    {
        private readonly dynamic _application;
        public ApplicationProxy(int version)
        {
            Type comType = Type.GetTypeFromProgID(String.Format("Sample.Application.{0}", version));
            _application = Activator.CreateInstance(comType);
        }
        public string Version
        {
            get { return _application.Version; }
        }
    }
