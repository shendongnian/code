    private void CopySEverything()
    {
        sEverythingCopy = new SEverything();
        sEverythingCopy.nameOfOwner = sEverythingOriginal.nameOfOwner;
        sEverythingCopy.arrayOfHouseNumbers = sEverythingOriginal.arrayOfHouseNumbers.ToArray();
    }
