    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using ReactiveUI;
    
    namespace Weingartner.Lens
    {
    
        public class Dyno : DynamicObject
        {
            private readonly DynamicNotifyingObject _D;
            public Dyno(DynamicNotifyingObject d)
            {
                _D = d;
            }
            
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                bool ret = base.TryGetMember(binder, out result);
    
                if (ret == false)
                {
                    result = _D.GetPropertyValue(binder.Name);
                    if (result != null)
                    {
                        ret = true;
                    }
                }
    
                return ret;
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                bool ret = base.TrySetMember(binder, value);
    
                if (ret == false)
                {
                    _D.SetPropertyValue(binder.Name, value);
                    ret = true;
                }
    
                return ret;
            }
        }
