    using (var enumerator = sequence.GetEnumerator())
    {
         while (enumerator.MoveNext())
         {
             if (veryExpensiveCheck) { ... }
             else if (cheapCheck)
             {
                 ...
                 break; //veryExpensiveCheck not needed anymore.
             }
         }
         while (enumerator.MoveNext())
         {
             if (cheapCheck) { ... }
         }
    }
