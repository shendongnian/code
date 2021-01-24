    public abstract class GenericReceiver
    {
        public enum Status
        {
            Fault1 = 0x0,
            Fault2 = 0x201
        }
    }
    public class DerivedReceiver
    {
        public enum Status
        {
            Fault1 = GenericReceiver.Status.Fault1,
            Fault2 = GenericReceiver.Status.Fault2,
            Fault3 = 0x302
        }
    }
