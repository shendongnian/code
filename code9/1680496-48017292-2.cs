    var bins = new int[10]; // Adjust this to size / use Dictionary if sparse
    var hiCount = 0;
    var smallestMostCommon = int.MaxValue;
    foreach(var a in arr)
    {
       var newCount = ++bins[a];
       if (newCount > hiCount) // 1st Precedence : Frequency
       {
          hiCount = newCount;
    	  smallestMostCommon = a;
       }
       else if (newCount == hiCount && a < smallestMostCommon) // 2nd : Lowest preferred
       {
    	  smallestMostCommon = a;
       }
    }
