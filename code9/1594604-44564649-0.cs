    try {
           //Active Directory properties loading here
           if(condition){ //Condition throws ArgumentException because of invalid AD Filter using characters
              return null;
           }
       }catch(ArgumentException ae){
          Console.WriteLine("AE caught : "+ae.ToString());
          throw;
       }
