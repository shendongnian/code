    Class Demo
    {
     
     
     static void main (string[] args)
     {
        var result=Add();
        Console.WriteLine(result[0]);
     }
      static List<int> Add ()
      {
        var listOfints= new List<int>();
        listOfints.Add(42); //either this or declare an array of integers and get it initialized by reading the user value and pass the same as param here to initialize and return the array
        return listOfints;
      }
  
    }
