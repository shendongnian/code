    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var type1 = Create<LoginModel>().InternalList;
    
                if (type1 != null)
                    Console.WriteLine("OK");
    
                Console.WriteLine("Finish");
    
                Console.ReadLine();
            }
    
            public static T Create<T>() where T : AbstractFactory
            {
                switch (typeof(T).Name)
                {
                    default:
                        return default(T);
    
                    case "UsersModel":
                        return new UsersModel() as T;
    
                    case "LoginModel":
                        return new LoginModel() as T;
                }
            }
        }
    
        internal abstract class AbstractFactory : IBaseInterface
        {
            public List<IBaseInterface> InternalList { get; set; }
        }
    
        internal interface IBaseInterface
        {
        }
    
        internal class UsersModel : AbstractFactory
        {
            public UsersModel()
            {
                InternalList = new List<IBaseInterface>();
            }
        }
    
        internal class LoginModel : AbstractFactory
        {
            public LoginModel()
            {
                InternalList = new List<IBaseInterface>();
            }
        }
    }
