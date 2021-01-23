    public class B
    {
      public bool Validate(ClassA a)
      {
        // Process ClassA / FormA object
        
         if (textIsEmpty == true)
                {
                    MessageBox.Show("Fill in the text fields");
                    return false;//Shouldnt this halt execution?
                }
           return true;
         
      }
    }
