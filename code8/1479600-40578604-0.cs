    public struct Lottery
    {
        public int[] numbers;
    }
    
    public static void Main()
    {
        var A = new Lottery();
        A.numbers = new[] { 1,2,3,4,5 };
        // struct A is in the stack, and it contains one reference to an array in RAM
   
        var B = A;
        // struct B also is in the stack, and it contains a copy of A.numbers reference
        B.numbers[0] = 10;
        // A.numbers[0] == 10, since both A.numbers and B.numbers point to same memory
        // You can't do this with strings because they are immutable
        B.numbers = new int[] { 6,7,8,9,10 };
        // B.numbers now points to a new location in RAM
        B.numbers[0] = 60;
        // A.numbers[0] == 10, B.numbers[0] == 60        
        // The two structures A and B *are completely separate* now.
    }
