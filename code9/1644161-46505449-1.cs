    public class Implementation1 : BaseClass, I1
    {
        public override void Resolver(Resolver resolver)
        {
             resolver.Resolve(this);
        }
        //...
    }
