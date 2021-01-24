    using System;
    public interface IBaseClass
    {
        string Id { get; set; }
    }
    public interface IChildClass : IBaseClass
    {
        new string Id { get; set; }
    }
    public class BaseClass : IBaseClass
    {
        public string Id { get; set; }
    }
    public class ChildClass : BaseClass, IChildClass
    {
        public new string Id { get; set; }
    }
    public class Program
    {
        static public void Main(string[] args)
        {
            ChildClass c = new ChildClass();
			((BaseClass)c).Id = "Base";
            c.Id = "Child";
			Console.WriteLine( ((BaseClass)c).Id);    // Base
			Console.WriteLine( ((ChildClass)c).Id);   // Child
			Console.WriteLine( ((IBaseClass)c).Id);   // Child !!!
			Console.WriteLine( ((IChildClass)c).Id);  // Child
        }
    }
