    private void CopySEverything()
    {
        sEverythingCopy = new SEverything();
        sEverythingCopy.nameOfOwner = sEverythingOriginal.nameOfOwner;
        sEverythingCopy.arrayOfHouseNumbers = new         
        int[sEverythingOriginal.arrayOfHouseNumbers.Length];
    
        for (int i = 0; i < sEverythingCopy.Length; i++)
        {
            sEverythingCopy[i] = sEverythingOriginal[i];
        }
    }
