     public static bool MyEnxtensionMethod<T>(T argument)
         where T: ICallable<T>
     {
          argument.CallMe();
          return true;
     }
