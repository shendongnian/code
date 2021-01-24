        for (i = 0; i < size; i++)
        {
            //Check if the stock on index i is between 1.5 and 35 and add 1 to the variable b
            if(arr[i] >=1.5 && arr[i] <=35.0){
                 b++
            }
        }
        //Printing the value on console
        Console.WriteLine("Average Price: "+ arr.Average() + " out of {0} stocks", x);
        Console.WriteLine("Minimum Price: "+ arr.Min());
        Console.WriteLine("Number of stocks priced between 1.5-35: "+ b);
        Console.ReadLine();
