    static void Main(string[] args)
    {
       // a new List has bee created with a set of integers
       List<int> numbers = new List<int>() { 2, 3, 4, 10, 12, 34 };
        
       // the numbers List is now being provided to the FindEvenNumber method,
       // but the results of the method are not used.
       FindEvenNumber(numbers);
       
       // To store the results of FindEvenNumber:
       List<int> evenNumbers = FindEvenNumber(numbers);
       
       // To use the results, loop over each item:
       foreach(int i in evenNumbers)
       {
          Console.WriteLine(i);
       }
    }
