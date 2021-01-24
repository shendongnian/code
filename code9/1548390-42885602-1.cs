    static void method1(int[] z)
    {
       z = new int[3]; // new instance created and z has reference to it
                       // while calling side still refers to old memory location
                       // which is { 13, 1, 5 }
       for(int m=0; m<z.Length;m++)
       {
            z[m] *= 2;
        }
    }
