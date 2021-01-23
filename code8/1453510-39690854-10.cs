     public bool IsPasswordCorrect(string password)
     {
          if(password != "fooBar")
             throw new InvalidPasswordException("You entered the wrong password. Try again");
          ....
     }
