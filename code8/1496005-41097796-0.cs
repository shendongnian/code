    public enum SexTypes { Unknown, Male, Female }
    public abstract class Human
    {
        protected string HelloMessage = "common message part";
        public abstract SexTypes Sex { get; }
        public void SayHello() => Console.WriteLine(HelloMessage); //good way
        public void SayHelloWithSwitch() //bad way
        {
            switch(Sex)
            {
                case SexTypes.Unknown:
                    Console.WriteLine(HelloMessage);
                    break;
                case SexTypes.Male:
                    Console.WriteLine(HelloMessage + " some modifications");
                    break;
                case SexTypes.Female:
                    Console.WriteLine("new other message");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class Boy : Human
    {
        public override SexTypes Sex => SexTypes.Male;
        protected new string HelloMessage => base.HelloMessage += " , some message modifications";
    }
    public class Girl : Human
    {
        public override SexTypes Sex => SexTypes.Female;
        protected new string HelloMessage = "overwrite all message";
    }
