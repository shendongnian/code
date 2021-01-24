    class Program
    {
        //Create a list of shirts
        static List<Shirt> shirtsList = new List<Shirt>();
 
        static void Main(string[] args)
        {
            //Create some shirts
            Shirt s1 = new Shirt("Cotten", "White", Sizes.L);
            Shirt s2 = new Shirt("Silk", "Blue", Sizes.M);
            Shirt s3 = new Shirt("Poly", "Red", Sizes.S);
            //Add shirts to shirt list 
            shirtsList.Add(s1);
            shirtsList.Add(s2);
            shirtsList.Add(s3);
            Console.WriteLine("*** List Of Shirts ***");
            Display(shirtsList);
            Console.WriteLine();
        }
        public static void Display(List<Shirt> shirts)
        {
            Console.WriteLine("Material\tColor\tSize");
            foreach (Shirt s in shirtsList)
                Console.WriteLine("{0}\t\t{1}\t{2}", s.Material, s.Color, s.Size );
        }
    }
