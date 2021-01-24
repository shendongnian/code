    ( class Program  
    {
        static void Main(string[] args)
        {
            int[] intArray = { 5, 12, 0, 67, 75, 3, 27, 1, 98};
            int[] searchValues = { 0, 25, 99, 12, 3 };
            
            foreach (int item in searchValues)
               if (intArray.Contains(item))
                   Console.Writeline("Item exists in list: ",item)
               else Console.Writeline("Item does not exist in list: ",item)
            
            Console.Read();
        }
    })
