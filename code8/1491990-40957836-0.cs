    //enumerate all lists in the outer list
    foreach ( var list in table )
    {
       //enumerate the inner list
       foreach ( var item in list )
       {
            //output the actual item
            Console.WriteLine( item );
       }
    }
