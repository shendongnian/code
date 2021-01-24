    public class Example
    {
        // Declared here and it will be defaulted to null since we never
        // initialized it explicitly.
        public int[] numero;
        // Or we can initialize it and declare it in one step:
        // public int[] numero = new int[5];
        public Example()
        {
            // Now we are in the constructor, we can use the variable and 
            // explicitly initialize it.
            numero = new int[5];
            int[] casinumero;
            casinumero = new int[4];
        }
        public void SomeMethod()
        {
            // Or we can use it in a method
            numero = new int[5];
        }
    }
