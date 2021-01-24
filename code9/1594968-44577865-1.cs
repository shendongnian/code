    public interface IMyInterface<T>
    {
        T GetInstance();
    }
    public class MysteryObject : IMyInterface<MysteryObject>
    {
        public MysteryObject GetInstance()
        {
            MysteryObject instance = new MysteryObject();
            return instance;
        }
    }
