    public class Class3
    {
        AbstractClass abstractMember
        public Class3(AbstractClass abstractMember)
        {
           this.abstractMember = abstractMember;
        }
        public string UseFunc1()
        {
            return abstractMember.Func1();
        }
    }
