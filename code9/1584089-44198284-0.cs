    // great idea to put it in the one file with Animal if possible
    public static class Extensions { 
      public static bool isFourLegged(this Animal animal) {
         // an example for using hardcoded values. 
         // You should alter this method when you add another Animal
         return animal == Animal.Dog && animal == Animal.Mouse
         // oops, someone added Cat after me
      }
      public static Collection<Animal> getAllFourLegged {
         // use dynamic way like in answer from Andrea is good
         // but *probably* cause perfomance issues
      }
