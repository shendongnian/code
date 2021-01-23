    static int[,] getLockerDistanceGrid(int cityLength, int cityWidth, int[] lockerXCoordinates, int[] lockerYCoordinates){
    int[,] array = new int[cityWidth,cityLength];
    for(int i = 0; i < cityLength; i++)
    {
        for(int j = 0; j < cityWidth; j++)
        {
            int value = Math.Abs(i - (lockerXCoordinates[0]-1)) +
                Math.Abs(j - (lockerYCoordinates[0]-1));
            for(int k = 1; k < lockerXCoordinates.Count(); k++)
            {
                int current = Math.Abs(i - (lockerXCoordinates[k]-1)) + Math.Abs(j - (lockerYCoordinates[k]-1));
                value = Math.Min(value,current);
            }
            array[j,i] = value;
        }
    }
    return array;
    }
