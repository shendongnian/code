    class Data {
      String Wbs { get; set; }
      String Csis { get; set; }
      String Bss { get; set; }
      String CsisAndBss() => Csis + Bss;
    }
    
    var list = new Data { ... }; // objects
    
    list.OrderBy( ... ); // Csis then Bss
    
    for(int i = 0; i < list.Count; list++){
      var actual = list[i];
      var before = list[i-1]; // check list boundaries
      if(i==0 || before.CsisAndBss != actual.CsisAndBss){
        actual.Wbs == "1.1";
        continue;
      }
      var values = before.Wbs.Split(".");
      actual.Wbs = $"{values[0]}.{Int32.Parse(values[1]+1)}";
    }
    // here pass data to the grid
