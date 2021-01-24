    // double cannot implicit convert to int -> F
    Console.WriteLine( ( (int)2 ).Equals( (double)2.0) );      //False
    // double cannot implicit convert to float -> F
    Console.WriteLine( ( (float)2.0 ).Equals( (double)2.0 ) ); //False
    // int can implicit convert to double -> T
    Console.WriteLine(((double)2.0).Equals((int)2));           //True
    // int can implicit convert to float -> T
    Console.WriteLine(((float)2.0).Equals((int)2.0));          //True
    // float can implicit convert to double -> T
    Console.WriteLine(((double)2.0).Equals((float)2.0));       //True
    // float cannot implicit convert to int -> F
    Console.WriteLine(((int)2).Equals((float)2.0));            //False
