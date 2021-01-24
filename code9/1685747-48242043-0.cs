    public abstract class ClassA
    {
        private int m_number;
        protected ClassA(int n)
        {
             m_number = n;
        }
    
        //protected abstract int GetNumber(); 
    }
    
    public class ClassB : ClassA
    {
        public ClassB() : base(10)
        {
        }
    
        //protected override int GetNumber()
        //{
        //    return 10;
        //}    
    }
