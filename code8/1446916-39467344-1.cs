    public class MyDynamic : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
               // I always set the result to null and I return true to tell
               // the runtime that I could get the value but I'm lying it!
               result = null;
               return true;
        }
    }
    dynamic myDynamic = new MyDynamic();
    string text = myDynamic.text; // This won't throw a runtime exception!
