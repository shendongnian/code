    class ClassName {
        public static int StaticField;
        public int InstanceField;
    }
    void Method(ref int i) { }
    void Test1(int valueParameter, ref int referenceParameter, out int outParameter) {
        ClassName instance = new ClassName();
        int[] array = new int[1];
        outParameter=0;
        int localVariable = 0;
        Method(ref ClassName.StaticField);  //Static variable
        Method(ref instance.InstanceField); //Instance variable
        Method(ref array[0]);               //Array element
        Method(ref valueParameter);         //Value parameter
        Method(ref referenceParameter);     //Reference parameter
        Method(ref outParameter);           //Output parameter
        Method(ref localVariable);          //Local variable
    }
