    using System;
    using System.Reflection;
    
    namespace SO40415991
    {
      class MyClass
      {
        public int MyFirstValue { get; set; }
    
        private int m_mySecondValue;
        public int MySecondValue
        {
          get { return m_mySecondValue; }
          set
          {
            m_mySecondValue = value;
          }
        }
    
      }
    
    
      class Program
      {
        static void Main(string[] args)
        {
          FieldInfo[] fis = typeof(MyClass).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    
          foreach (var fi in fis)
          {
            Console.WriteLine($"{ fi.Name} {fi.IsPrivate}");
          }
    
          Console.WriteLine();
          Console.WriteLine("END");
          Console.ReadLine();
        }
      }
    }
