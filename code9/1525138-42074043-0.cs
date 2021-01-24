    class Module 
    {
        public Module() 
        {
            this.Children = new List<Module>();
        }
        public string ModuleCode {get; set;}
        public string ParentCode {get; set;}
        public Module Parent {get; set;}
        public List<Module> Children {get; private set;}
    }
    static void main()
    {
        List<Module> moduleList = GetFlattenedModules();
        IDictionary<string, Module> moduleCodeToModule = 
            moduleList.ToDictionary(m => m.ModuleCode);
        foreach (Module module in moduleList)
        {
            if (module.ParentCode != null) 
            {
                module.Parent = moduleCodeToModule[module.ParentCode];
                module.Parent.Children.Add(module);
            }
        }
    }
