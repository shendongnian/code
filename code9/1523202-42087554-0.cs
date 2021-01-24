    public class CustomAssemblyResolver : IAssembliesResolver
    {
        public List<string> PluginNames { get; set; }
    
        public CustomAssemblyResolver()
        {
            PluginNames = new List<string>();
    
            //Add the custom libraries here
            PluginNames.Add("Your_Second_Library");
        }
    
        public ICollection<Assembly> GetAssemblies()
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies().ToList();
            foreach (var name in PluginNames)
            {
    
                var asmPath = System.IO.Path.Combine(HostingEnvironment.MapPath("~/"), name + ".dll");
                try
                {
                    var asm= System.Reflection.Assembly.LoadFrom(asmPath);
                    if(!asms.Contains(asm))
                        asms.Add(asm);
                }
                catch (Exception)
                {
                            
                }
            }
            return asms;
        }
    }
