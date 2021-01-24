    class Trade {
      //..
      public string WaveCSV {
        get {
          return string.Join(",", Waves.Select(w => w.Prop1).ToArray()); 
        }
      }
    }
