    struct Test
    {
      public string int { get; set; }
      public string int { get; set; }
    }
    //...
    var array1 = new Test[] 
    {
      new Test { Field = 0, OtherField = 1 },
      new Test { Field = 1, OtherField = 2 }
    }
    var array2 = new Test[] 
    {
      new Test { Field = 0, OtherField = 1 },
      new Test { Field = 2, OtherField = 2 }
    }
