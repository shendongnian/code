    public class ClassA
    {
        public ClassA(BaseConstants constants)
        {
             Constants = constants;
        }
    
        private BaseConstants Constants { get; }
    
        public int NumberOfPeople => Constants.GetNumberOfPeople(); 
    }
