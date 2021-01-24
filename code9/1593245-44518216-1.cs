    public class DisableReferencePreservationContractResolver : DefaultContractResolver
    {
        readonly HashSet<Type> types;
        public DisableReferencePreservationContractResolver(IEnumerable<Type> types)
        {
            this.types = new HashSet<Type>(types);
        }
		
        bool ContainsType(Type type)
        {
            return types.Contains(type);
            //return types.Any(t => t.IsAssignableFrom(type));
        }
        bool? GetIsReferenceOverride(Type type)
        {
            return ContainsType(type) ? false : (bool?)null;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            // Disable IsReference for this type of object
            var contract = base.CreateContract(objectType);
            contract.IsReference = contract.IsReference ?? GetIsReferenceOverride(objectType);
            return contract;
        }
    }
