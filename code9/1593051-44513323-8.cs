    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    
    namespace DynamicObjectGetterOverride {
        public sealed class LoggedPropertyAccess : DynamicObject {
            public readonly Dictionary<string, object> __Properties = new Dictionary<string, object>();
            public readonly HashSet<string> __AccessedProperties = new HashSet<string>();
    
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                if (!__Properties.TryGetValue(binder.Name, out result)) {
                    var ret = new LoggedPropertyAccess();
                    __Properties[binder.Name] = ret;
                    result = ret;
                }
                __AccessedProperties.Add(binder.Name);
                return true;
            }
    
            //this allows for setting values which aren't instances of LoggedPropertyAccess
            public override bool TrySetMember(SetMemberBinder binder, object value) {
                __Properties[binder.Name] = value;
                return true;
            }
    
            private static Dictionary<Type, Func<object>> typeActions = new Dictionary<Type, Func<object>>() {
                {typeof(string), () => "dummy string" },
                {typeof(int), () => 42 },
                {typeof(DateTime), () => DateTime.Today }
            };
    
            public override bool TryConvert(ConvertBinder binder, out object result) {
                if (typeActions.TryGetValue(binder.Type, out var action)) {
                    result = action();
                    return true;
                }
                return base.TryConvert(binder, out result);
            }
        }
    }
