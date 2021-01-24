    foreach (int k in CityDataHT.Keys)
      {
         CityData city = (CityData)CityDataHT[k];
         Console.WriteLine(
           city.City + " - " +city.Country
         );
         // Prints "City - Country"
      } 
