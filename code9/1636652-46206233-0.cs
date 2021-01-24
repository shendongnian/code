      public class MyClass<T> {
        private Dictionary<string, T> m_Values = new Dictionary<string, T>();
    
        public T this[string name] {
          get {
            return m_Values[name];
          }
          set {
            if (m_Values.ContainsKey(name))
              m_Values[name] = value;
            else
              m_Values.Add(name, value);
          }
        }
      }
    
      ...
    
      var test = new MyClass<int>();
    
      test["abc"] = 1;
      test["x"] = 2;
      test["pqr"] = 55;
    
      Console.WriteLine(test["x"]);
