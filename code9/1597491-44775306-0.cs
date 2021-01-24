     private static extern Type GetSomeType();
        static void Main(string[] args)
        {
            TypeBuilder foo = (TypeBuilder)GetSomeType();
            if(foo.IsCreated())
            {
                // foo is a type -- you can't change it anymore
            }
            else
            {
                // foo is not yet created, you can add methods and properties
            }
        }
