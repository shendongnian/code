    public class Entity<T1, T2, T3, T4>
    {
      public virtual T1 Field1 {get;set;}
      public T2 Field2 { get; set; }
      public T3 Field3 { get; set; }
      public T4 Field4 { get; set; }
    }
    
    public class Derived : Entity<int, string, bool, int>
    {
        public override int Field1 { get; set; }
    }
