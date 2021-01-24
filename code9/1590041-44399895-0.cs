    public void checkHuman<T>(T my_human) where T : human
    {
        
        var woman = my_human as woman;
        if (woman != null)
        {
            Console.WriteLine(string.Format("{0} is {1}", woman.name, woman.isPregnant ? "pregnant." : "not pregnant."));
        }
        else
        {
            var man = my_human as man;
            Console.WriteLine(string.Format("{0} has {1} computers", man.name, man.numberOfComputers));
        }
    }
