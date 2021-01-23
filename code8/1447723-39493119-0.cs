    using System.Dynamic;
    public class A : DynamicObject
    {
        public dynamic this[string p] => this;
	
        public override bool TryInvoke( InvokeBinder binder, object[] parameters, out object result )
        {
            result = this;
            return true;
        }
    }
