    private  static int CalcProductTailRecHelper(int num, int res)
    {
       int length = num.ToString().Length;
       if (length == 1)
       {
           return res;
       }
       return CalcProductTailRecHelper(num / 10 res*(num % 10));
    }
    private  static int CalcProductTailRec(int num){
        CalcProductTailRecHelper(Math.Abs(num), 1)
    }
