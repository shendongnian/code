    List <Monster> monsterList = new List<Monster> ();
    public FunMachine()
    {       
        List <Monster> monsterList = new List<Monster> ();
        FunMachineState entryHall = new FunMachineState("...", "...", "...", true, 
           new Dictionary<int, Monster> (){{7, monsterList.Find(x => x.name.Contains("orc"))}}, false);
    //...
    }
