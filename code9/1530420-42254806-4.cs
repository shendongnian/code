    public class ModelNameResolver : IMemberValueResolver<object, object, int?, string>
    {
        // create or assign _inventoryService
        // also note objects as source and destination
        public string Resolve(object source, object destination,
           int? sourceMember, string destMember,
           ResolutionContext context)
        {
             if (!sourceMember.HasValue)
                return "n/a";
             return _inventoryService.GetModel(sourceMember.Value).Name;
        }
    }
