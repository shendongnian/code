    namespace PetesExtensions 
    {
      public static class PetExtensions 
      {
        public static string[] GetLegs(this Pet pet)
        {
          if (pet == null) throw new ArgumentNullException("pet");
          if (pet is Cat) return ((Cat)pet).GetLegs();
          if (pet is Parrot) return ((Parrot)pet).GetLegs();
          throw new Exception(
            $"I don't know how to get the legs of a {pet.GetType().Name}. Contact Pete Moloy.");
        } 
      }
    }
