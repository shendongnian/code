    public class SealedPersonWrapper
    {
        public SealedPersonWrapper(SealedPerson person)
        {
            this.Prop1 = person.Prop1;
        }
    
        public string Prop1 {get; private set;}
    }
