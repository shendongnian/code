    class CommandFactory
    {
        private readonly Dictionary<string, Func<Person, PersonCommand>> creationFuncs;
    
        CommandFactory(string backendUrl)
        {
            creationFuncs = new Dictionary<string, Func<Command>>();
    
            creationFuncs.Add("add", (person) => return new AddCommand(backendUrl, person));
            creationFuncs.Add("update", (person) => return new UpdateCommand(backendUrl, person));
            creationFuncs.Add("delete", (person) => return new DeleteCommand(backendUrl, person));
        }
        PersonCommand Create(string action, Person person)
        {
            // validation can be added here
            return creationFuncs[action](person);
        }
    }
