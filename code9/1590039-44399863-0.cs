    public void CheckHuman(Human human)
    {
        if (human is Woman)
        {
            var woman = (Woman)human;
            Console.WriteLine("{0} is {1}pregnant.", woman.Name, woman.IsPregnant ? "" : "not ");
        }
        else if (human is Man)
        {
            var man = (Man)human;
            Console.WriteLine("{0} has {1} computers.", man.Name, man.NumberOfComputers);
        }
    }
