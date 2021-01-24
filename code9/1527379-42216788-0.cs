    class Program
    {
       //Author         : Mudrak Patel
       //Github username: mudrakpatel
       
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            List<double> doubleList = new List<double>();
            for (int index = 0; index < 12; index++)
            {
                intList.Add(index);
                doubleList.Add((double)index);
            }
            Console.WriteLine("\nAll elements of integer array\n--------------------------------------------------------");
            DisplayArray(intList.ToArray());
            Console.WriteLine("\nAll elements of double array\n--------------------------------------------------------");
            DisplayArray(doubleList.ToArray());
            Console.WriteLine("\nAll elements of integer array from 3rd place to 8th place\n--------------------------------------------------------");
            DisplayArray(intList.ToArray(), 3, 8);
            Console.WriteLine("\nAll elements of double array from 3rd place to 8th place\n--------------------------------------------------------");
            DisplayArray(doubleList.ToArray(), 3, 8);
        }
        //Overloaded DisplayArray method
       public static void DisplayArray<Type>(Type[] inputCollectionObject)
        {
            for (int index = 0; index < inputCollectionObject.Length; index++)
            {
                Console.WriteLine("Element: {0,2}", inputCollectionObject[index]);
            }
            Console.WriteLine("-----------------------------------------------");
        }
        public static void DisplayArray<Type>(Type[] inputCollectionObject, int lowIndex , int highIndex)
        {
            var selectedElements = new List<int>();
            for (int index = lowIndex; index < highIndex; index++)
            {
                selectedElements.Add(Convert.ToInt32(inputCollectionObject[index]));
            }
            Console.WriteLine("The elements within the range you specified:\n--------------------------------------------------");
            foreach (var element in selectedElements)
            {
                Console.WriteLine("Element: {0,2}", element);
            }
        }
    }
