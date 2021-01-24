    [assembly: Dependency(typeof(AppGetName ))]
    namespace YourNamespace 
     ....
     public class AppGetName : IGetName
       {
           public string GetName (string value)
           {
                 System.Resources.ResourceManager rm = typeof(AppResources)
                    .GetRuntimeFields()
                    .First(m => m.Name == "resourceMan")
                    .GetValue(typeof(AppResources)) as 
          System.Resources.ResourceManager;
    
        
    
        //CultureInfo culture 
        ResourceSet rs = rm.GetResourceSet(culture, true, false); 
        var nameItem = rs.OfType<DictionaryEntry>().FirstOrDefault(i => i.Value == "YourValue"); 
        var name = nameItem.Key.ToString();
        return name;
           }
       }
