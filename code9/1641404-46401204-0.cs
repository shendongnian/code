    public class ResourceProvider : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var resourceName = binder.Name;
            
            result = MyResources.ResourceManager.GetString(resourceName);
            // You'll want some error checking here, and return false if the resource does not exist 
            // (or throw an exception, return a default string, etc).
            return true;
        }
    }
