    public class MyClassFactory : IMyClassFactory
    {
        private Dictionary<string, Action<IClass>> _factory =
            new Dictionary<string, Action<IClass>>
            {
                ["Folder1.MyClass"] = () => new ConsoleApplication1.Folder1.MyClass(),
                ["Folder2.MyClass"] = () => new ConsoleApplication1.Folder2.MyClass(),
                ...
            };
        public IClass GetClassInstance(string myClassName)
        {
            if (_factory.Contains(myClassName))
            {
                return _factory[myClassName]();
            }
            throw NoSuchClassException(myClassName);
        }
    } 
