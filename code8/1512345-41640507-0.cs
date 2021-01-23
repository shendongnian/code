    public int AddDigits(int num) {
        if(num > 9)
        {
            return AddDigits(num/10) + num%10;
        }
        else{
            return num;
        }
    }
