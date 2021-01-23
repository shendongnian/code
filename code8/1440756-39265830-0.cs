    void Main()
    {
    
        var e = SomeEntity.GetEntities(new List<int> { 1, 2, 3});
        e.Dump();
    }
    
    public class SomeEntity
    {
        public int m_i;
        public SomeEntity(int i)
        {
            m_i = i;
        }
    
        public override string ToString()
        {
            return m_i.ToString();
        }
    
    
        public static int someFunction(int i){ return i+100;}
        
        public static IEnumerable<SomeEntity> GetEntities(IEnumerable<int> someArray)
        {
    //        for (int i = 0; i < someArray.Count();i++)
    //            yield return new SomeEntity(someFunction(i));
            
            // *** Equivalent linq function ***    
            return someArray.Select(a => new SomeEntity(someFunction(a)));    
        }
    }
    
