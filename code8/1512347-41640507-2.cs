    public int AddDigits(int num, bool root = true) {
        if(num > 9)
        {
            var sum = num;
           
            if(root)
            {
                while(sum > 9)
                {
                    sum = AddDigits(sum/10, false) + sum%10;
                }
                return sum;
            }
            else return AddDigits(num/10, false) + num%10;
        }
        else{
            return num;
        }
    }
