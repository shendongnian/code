    public class ValuesChangedMessage : MvxMessage
    {      
        public ValuesChangedMessage(object sender, int valuea, string valueb)
            : base(sender)
        {
            Valuea = valuea;
            Valueb = valueb;        
        }
        public int Valuea { get; private set; }
        public string Valueb { get; private set; }
    }
