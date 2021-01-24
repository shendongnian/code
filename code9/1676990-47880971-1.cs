    public class MyClass
    {
        public static int number = 2;
        public void Calc(int number) //when number: 4
        {
            int result1 = number * 3;         //result1: 12
            int result2 = MyClass.number * 3; //result2: 6
        }
    }
