    class Program
    {
        static void Main(string[] args)
        {
            var A = new Student() { ID=101, Name="Peter" };
            var B = A.InsertAfter(new Student() { ID=102, Name="John" });
            var C = B.InsertBefore(new Student() { ID=103, Name="Mary" });
            //          [A]----[C]----[B]
            //           |      |      |
            // ID       101    103    102
            // Name    Peter  Mary   John
            // IsRoot  true   false  false 
            // IsLeft  false  false  true
            // CountL    0      1      2
            // CountR    2      1      0
        }
    }
