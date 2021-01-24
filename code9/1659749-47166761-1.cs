     // ['a'..'z', 0..9, 0..19] bool array (first index is not zero-based)
     bool[,,]cells = (bool[,,]) Array.CreateInstance(
       typeof(bool),              // Array items type
       new int[] { 26, 10, 20 },  // Sizes
       new int[] { 'a', 0, 0 });  // Lower bounds 
     ...
     // Single item addressing
     cells['b', 1, 4] = true;
     ...
     // Loop over all the array's items
     for (int i = cells.GetLowerBound(0); i <= cells.GetUpperBound(0); ++i)
       for (int j = cells.GetLowerBound(1); j <= cells.GetUpperBound(1); ++j)
         for (int k = cells.GetLowerBound(2); k <= cells.GetUpperBound(2); ++k) { 
           // ... cells[i, j, k] ...
         }
