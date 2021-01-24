    public class AddOnBag : DynamicObject
    {
        private Dictionary<string, string> _addOns;
        public static AddOnBag BuildBag(Dictionary<string, string> dict)
        {
            var bag = new AddOnBag {_addOns = dict};
            return bag;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var addOn = LookupAddOn(binder.Name);
            
            result = addOn.Value;
            
            return addOn.Key != null;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var addOn = LookupAddOn(binder.Name);
            if (addOn.Key == null)
            {
                return false;
            }
            _addOns[addOn.Key] = value.ToString();
            return true;
        }
        private KeyValuePair<string, string> LookupAddOn(string name)
        {
            var addOn = _addOns.FirstOrDefault(pair =>
            {
                var stripped = pair.Key.Replace(" ", string.Empty);
                var attempted = name;
                return string.Equals(stripped, attempted, StringComparison.OrdinalIgnoreCase);
            });
            return addOn;
        }
    }
