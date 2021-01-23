    public static double arraySum(ulong[] arrN)
    {
        double sum = 0;
        foreach (ulong k in arrN){
            sum+=(double)k;
        }
        return sum;
    }
    
    ulong[] chessArray = new ulong[64]
    //filling values of chessArray, 1st element is 1, 2nd is 2, 3rd is 4 etc.    
    ulong a = arraySum(chessArray);
