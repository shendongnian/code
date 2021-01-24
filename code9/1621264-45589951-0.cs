    class Test
    {
        private int field;
        public void ShowExample()
        {
            // set the value
            field = 12;
            // call the method and pass *a reference* to the field
            // note the special syntax
            MutateField(ref field);
            // the field, which is a value type, was mutated because it was passed as a reference
            Console.WriteLine(field == 4);
        }
        private static void MutateField(ref int value)
        {
            value = 4;
        }
    }
