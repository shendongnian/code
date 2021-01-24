    public class ScrewyDynamicWrapper : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // get your actual value based on the property name
            Console.WriteLine("Get Property: {0}", binder.Name);
            result = null;
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            // set your actual value based on the property name
            Console.WriteLine("Set Property: {0} # Value: {2}", binder.Name, value);
            return true;
        }
    }
