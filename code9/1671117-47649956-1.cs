    public void FilterOrder(Order filter)
    {
        Console.WriteLine("What numerical value would you like the information to be greater than?");
        double Value = Convert.ToInt32(Console.ReadLine());
          for (int i = 0; i< orders.Length; i++)
        {
           if(orders.get(i).GetAmount()>Value){
               //print orders.get(i) here
            }
           
        }
    }
