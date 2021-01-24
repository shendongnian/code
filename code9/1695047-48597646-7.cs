    public static double Factorial(int number, int number2)
    {
        if (number == 1 && number2 == 1)
        {
            return 1;
        }
    
        double facNum = 1;
        double facNum2 = 1;
    
        // counting up is easier, we start at 2 as we initialized to 1
        // we count up to the max of both numbers
        for (int i = 2; i <= Math.Max(number, number2); i++) 
        {
            if (i <= number)
                facNum *= i;  // we mult this until we reached number
    
            if (i <= number2)
                facNum2 *= i; // we mult this until we reach number2
        }
    
        // return the devision of both - this wont handle number < number2 well!
        return facNum / facNum2; // do this outside the loop
    }
