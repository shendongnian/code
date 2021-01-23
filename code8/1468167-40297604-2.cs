    using System.Collections;
    
    class C
    {
        static void Main()
        {
            object[] array = { };
            IList list = new ArrayList();
            list.CopyTo(array, 0); // Works okay
            dynamic index = 0;
            list.CopyTo(array, (int) index); // Works okay
        }
    }
