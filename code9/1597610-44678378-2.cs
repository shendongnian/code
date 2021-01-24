    static void Main(string[] args)
    {
        // create a list to hold the transitions we load
        List<AbstractTransition> transitions = new List<AbstractTransition>();
    
        // load each module we find in the modules directory
        foreach (string dllFilepath in Directory.EnumerateFiles("Modules", "*.dll"))
            // this should really read from the app config to get the module directory                
        {
            Assembly dllAssembly = Assembly.LoadFrom(dllFilepath);
    
            transitions.AddRange(dllAssembly.GetTypes()
                .Where(type => typeof(AbstractTransition).IsAssignableFrom(type))
                .Select(type => (AbstractTransition) Activator.CreateInstance(type)));
        }
    
        // show what's been loaded
        foreach (AbstractTransition transition in transitions)
        {
            Console.WriteLine("Loaded transition with id {0}", transition.TransitionId);
    
            // execute just to show how it's done
            transition.PerformTransition();
        }
    
        Console.Read(); // pause
    }
