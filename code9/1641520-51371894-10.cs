    public class BaseApiController : ApiController
    {
        public ModelStateDictionary ModelStateAsCamelCase()
        {
            var newModelStateDictionary = new ModelStateDictionary();
            foreach (var element in ModelState)
            {
                if (!string.IsNullOrWhiteSpace(element.Key))
                {
                    var keys = element.Key.Split('.');
                    List<string> camelKeys = new List<string>();
                    foreach (var key in keys)
                    {
                        camelKeys.Add(key.First().ToString().ToLowerInvariant() + key.Substring(1));
                    }
                     
                    // You can (add a / change this) code if the returned key is not
                    // composed from the ObjectName.Property, such as when it is 
                    // composed from the property name
                    var newKey = camelKeys.Aggregate((i, j) => i + "." + j);
                    newModelStateDictionary.Add(newKey, element.Value);
                }
                else
                    newModelStateDictionary.Add(element);
            }
            return newModelStateDictionary;
        }
    }
