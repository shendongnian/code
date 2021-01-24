     case 2:
        Cow cowWithBestMilk; //Used to save the cow with the most milk production
        ///Lets Search
        for( int i = 0; i < animals.Count; ++i)
        {
          //check lifestock, but only cows
          if( LivestockType == "Cow" )
          {
            //Amount to check of my livestock
            double livestockMilk = animals[i].getMilkAmount(); //<-- fantasy code, you have to acces here the AmountMilk of your cow
           if(cowWithBestMilk != null)
           {
              //check if the cow from the lifestock got more milk than the other cow
              if( livestockMilk > cowWithBestMilk.getMilkAmount() ) //<-- you can use >= instead of > if you want to have the last cow with the same amount
              {
                 cowWithBestMilk = animals[i]; 
              }
           }
           else
           {
             //there was no other cow until now
             cowWithBestMilk = animals[i];
           }
            
          } //if type cow
        } //for
        if( cowWithBestMilk != null)
        {
          Console.WriteLine("Cow that produced the most Milk:" + cowWithBestMilk.getHerIdAsString() ); //<--fantasy code here
        }
        else
        {
          Console.WriteLine("Who let the cows out?");
        }
        
        break;
