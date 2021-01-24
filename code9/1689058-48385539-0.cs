    public class ClassTwo
    {
        public void MyLocalMethod()
        {
            ClassOne OriginalClass = new ClassOne();
            OriginalClass.MyMethod();
            var LocalID = OriginalClass.ID;  //I want LocalID to equal 22, but 
    obviously doesn't
        }
    }
