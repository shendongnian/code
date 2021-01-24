    Idx1 = 0; Idx2 = 0;
    while (true)
    {
        // scan arrays until both indexes point to the same LinkedColumn
        // here we assume that both arrays are sorted by LinkedColumn
        // and that values in LinkedColumn are unique
        
        while (Idx1 < Array1.Length && Idx2 < Array2.Length &&
            Array1[Idx1].LinkedColumn < Array2[Idx2].LinkedColumn)
        {
            // move along Array1
            Idx1++;
        }
        
        while (Idx1 < Array1.Length && Idx2 < Array2.Length &&
            Array1[Idx1].LinkedColumn > Array2[Idx2].LinkedColumn)
        {
            // move along Array2
            Idx2++;
        }
        
        // at this point both indexes point to the same LinkedColumn
        // or one or both of the arrays are over
        
        if (Idx1 >= Array1.Length || Idx2 >= Array2.Length)
        {
            break;
        }
        
        // compare the values
        if (Array1[Idx1].CompareColumn != Array2[Idx2].CompareColumn)
        {
            // TODO: output/save/print the difference
        }
        
        Idx1++; Idx2++;
    }
