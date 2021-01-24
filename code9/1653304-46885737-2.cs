    Console.WriteLine( ( (int)2 ).Equals( (double)2.0) );      //False
    Console.WriteLine( ( (float)2.0 ).Equals( (double)2.0 ) ); //False
    Console.WriteLine(((double)2.0).Equals((int)2));           //True
    Console.WriteLine(((float)2.0).Equals((int)2.0));          //True
    Console.WriteLine(((double)2.0).Equals((float)2.0));       //True
    Console.WriteLine(((int)2).Equals((float)2.0));            //False
