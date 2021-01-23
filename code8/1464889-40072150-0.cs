    public double DetermineHighest()
    {
      highest = -273 // degrees
      for (int x = 0; x < DaysCount; x++) //Traverse through the week's temperatures
      {
        if (weeksTemperatures[x] > highest)  //find the highest temperature of the week
        {
          highest = weeksTemperatures[x];  //and set it to highest
        }
      }
      return highest;
    }
