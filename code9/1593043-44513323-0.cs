    public sealed class LoggedPropertyAccess : DynamicObject {
        public readonly HashSet<string> accessedPropertyNames = new HashSet<string>();
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            accessedPropertyNames.Add(binder.Name);
            result = "";
            return true;
        }
    }
