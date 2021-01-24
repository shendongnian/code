    public interface IMyInterface
    {
        IMyInterface GetInstance();
    }
    public class MysteryObject : IMyInterface
    {
        public IMyInterface GetInstance()
        {
            MysteryObject instance = new MysteryObject();
            return instance;
        }
    }
