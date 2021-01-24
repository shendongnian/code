    var x = collection.Select(x => 
                                   {
                                       int value;
                                       if (x.Property != null)
                                       {
                                           value = x.Property;
                                       }
                                       else
                                       {
                                           value = 10;
                                       }
                                       return new SomeClass(value);
                                   }
                             );
