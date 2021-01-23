    Tool tool = new Tool(){Factories = new List<Factories>()};
    Factory factory = new Factory(){Name = flatList[0][1], Machines = new List< Machine>()};
    tool.Factories.Add(factory);
    Machine machine = new Machine(){Name = flatList[0][2], Modules = new List<Module>()};
    factory.Machines.Add(machine);
    Module module = new Module(){Name = flatList[0][3]};
    machine.Modules.Add(module);
    bool isNewMachine = false;
    bool isNewModule = false;
    
