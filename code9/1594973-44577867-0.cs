    IMyInterface<T>
      {
        T GetInstance();
      }
    
    public class MysteryObject : IMYInterface<MysteryObject>
    }
      public MysteryObject GetInstance()
        {
          MysteryObject instance = new MysteryObject();
          return instance;
        }
    }
