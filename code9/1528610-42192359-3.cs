    public class ClassB
    {
        private double memberX;
        private double memberY;
        public ClassB(double x, double y)
        {
            memberX = x;
            memberY = y;
        }
    
        public double GetMember1() { return memberX; }
        public double GetMember2() { return memberY; }
        public double AFunction() 
        {
            bool condition = ...
            return condition ? memberX : memberY;
        }
    }
