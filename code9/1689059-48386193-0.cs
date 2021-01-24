    public class ClassTwo
    {
        public void MyLocalMethod()
        {
            ClassOne OriginalClass = new ClassOne();
            OriginalClass.myMethod();
            var LocalID = OriginalClass.ID;
       }
    }
