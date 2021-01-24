     foreach(var result in myClass.Result){
        // do something with the list
        // compare only, if oldResult is not empty
        if(oldResult.Count == 0) continoue;
        foreach(var oldResult in _oldResult ){
          if(result.MarketName.Equals(oldResult.MarketName)){
             if(result.Volume > oldResult.Volume)
             {
                Console.WriteLine("Volume: " + result.Volume);
                Console.WriteLine("Volume: " + oldResult .Volume);
             }
             
             break;
          }
        }
     }
     _oldResult = myClass.Result;
