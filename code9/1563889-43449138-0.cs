    static class Factory
    {
       public static T Instance<T>()
       {
         // diContainer can be static as its mostly thread safe
         return diContainer.GetInstance<T>();
       }
    }
