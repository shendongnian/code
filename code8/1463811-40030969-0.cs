    class A
    {
        Class B
        { 
            public int X;
            public static int Y;
        }
    }
    Class C
    {
        void Function1(A.B instanceOfB){
            int x=instanceOfB.X; // get value of non-static field X
            int y=A.B.Y; // get value of static field Y
        }
    }
