    public void CheckHuman(Human human)
    {
        if (human is Woman woman)
        {
            Console.WriteLine("{0} is {1}pregnant.", woman.Name, woman.IsPregnant ? "" : "not ");
        }
        else if (human is Man man)
        {
            // please keep in mind that women have computers too
            Console.WriteLine("{0} has {1} computers.", man.Name, man.NumberOfComputers);
        }
    }
