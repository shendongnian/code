    public static int SumDigits(int n) 
    { 
      int sum = n.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).Sum(); 
      return sum > 9 ? SumDigits(sum): sum; 
    }
