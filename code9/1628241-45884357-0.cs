        //input string
        string numbers = "12467930";
        string result = string.Empty;
        for (int i = 0; i < numbers.Length; i++)
        {
            //This should keep it running one more time unnecessarily.
            if(i + 1 < numbers.Length){
                 result += numbers[i];
                 break;
            }else{
                 int value2 = (int)char.GetNumericValue(numbers[i + 1]);
            }
            int value1 = (int)char.GetNumericValue(numbers[i]);
             //check if it's zero
             if(value1 != 0 || value2 !=0){
                   //if they are both odd add a hyphen
                   if (value1 % 2 != 0 && value2 % 2 != 0){
                         result += numbers[i] + "-";
                   //otherwise they are even and not zero add an asterisk
                   }else{
                         result += numbers[i] + "*";
                   }
             //otherwise one number is zero or they are both the same type odd/even
             }else{
                   result += numbers[i];
             }
        }
        return result;
