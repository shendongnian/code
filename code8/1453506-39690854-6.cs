    public class DataBase
    {
         public bool IsPasswordCorrect(string password)
         {
              if(password != "fooBar")
                 return false;
              else
                 return true;
         }
    }
    ....
    if(!db.IsPasswordCorrect("notA_fooBar"))
       MessageBox.Show("You entered the wrong password. Try again");
    else
       ....
