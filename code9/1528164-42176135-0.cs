    // Defines a module as having a name and a list of modules it depends on to be eligible
    class Module
    {
        public string Name { get; set; }
        public List<Module> DependsOn { get; set; }
    }
    
    // Represents a solution as a list of modules
    class Solution
    {
        public List<Module> Modules { get; set; }
    }
    class Program
    {
        static void Main( string[] args )
        {
            // Defines the modules
            var if01 = new Module() { Name = "IF01" };
            var if02 = new Module() { Name = "IF02" };
            var if03 = new Module() { Name = "IF03" };
            var if04 = new Module() { Name = "IF04" };
            var if05 = new Module() { Name = "IF05" };
            var if06 = new Module() { Name = "IF06" };
            var if07 = new Module() { Name = "IF07" };
            var if08 = new Module() { Name = "IF08" };
            var if09 = new Module() { Name = "IF09" };
            // Defines on which other modules each module depends on
            if01.DependsOn = new List<Module>();
            if02.DependsOn = new List<Module>() { if01 };
            if03.DependsOn = new List<Module>() { if01, if02 };
            if04.DependsOn = new List<Module>();
            if05.DependsOn = new List<Module>() { if04 };
            if06.DependsOn = new List<Module>() { if05 };
            if07.DependsOn = new List<Module>() { if03, if06 };
            if08.DependsOn = new List<Module>() { if03 };
            if09.DependsOn = new List<Module>() { if07, if08 };
            // The list of all modules
            var allModules = new List<Module>() { if01, if02, if03, if04, if05, if06, if07, if08, if09 };
            // The list of choosen modules at this step
            var choosenModules = new List<Module>();
            // Writes each found solution
            foreach ( var solution in Calculate( choosenModules, allModules ) )
            {
                solution.Modules.ForEach( m => Console.Write( m.Name + "/" ) );
                Console.WriteLine();
            }
        }
        // Determinates if a module is eligible considering already choosed modules
        static bool IsEligible( Module module, List<Module> alreadyChoosed )
        {
            // All modules this module depends on needs to be present in the allready choosen modules
            return module.DependsOn.All( m => alreadyChoosed.Contains( m ) );
        }
        static IEnumerable<Solution> Calculate( List<Module> choosenModules, List<Module> remainingModules )
        {
            if ( remainingModules.Count > 0 )
            // If some modules remain, we need to continue
            {
                // Takes the list of all eligible modules at this step
                var allEligibleModules = remainingModules.FindAll( m => IsEligible( m, choosenModules ) );
                // We explore the solutions
                foreach ( var newlyChoosen in allEligibleModules )
                {
                    // Considering this newly choosen module...
                    choosenModules.Add( newlyChoosen );
                    // ... which is so no more in the remaining modules
                    remainingModules.Remove( newlyChoosen );
                    // And try to find all solutions starting with this newly choosen module
                    foreach ( var solution in Calculate( choosenModules, remainingModules ) )
                        yield return solution;
                    // As we have tested this module we push it back as unchoosed, so that the next possible will take its place in the solution
                    choosenModules.Remove( newlyChoosen );
                    remainingModules.Add( newlyChoosen );
                }
            }
            else
            // If no more remaining modules, we have a solution
                yield return new Solution() { Modules = new List<Module>( choosenModules ) };
        }
