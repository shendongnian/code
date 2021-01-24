    namespace MyProgram
    {
        public class ParentClass
        {
            public int calc( int a)
            { 
                return a + this.cal();
            }
    
            public virtual int cal()
            {
                return 2;
            } 
        }
    
        public class childClass : ParentClass
        {
            public override int cal() // same name and firm 
            {
                return 1;
            }
        }
    }
