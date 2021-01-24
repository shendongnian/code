      using System.Dynamic;
      ... 
      dynamic test = new ExpandoObject();
      test.abc = 1;
      test.x = 2;
      test.pqr = 55; 
      Console.WriteLine(test.x);   
