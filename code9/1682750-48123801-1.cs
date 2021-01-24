    class Creature
    {
        int _heathPoint;
        // Below is something new.
        // Please note that although it looks like a ordinary method like DoSomething(),
        // it lacks the return type and has the same name as the class name
        // Such a method is called **constructor**
        public Creature()
        {
            _healthPoint = 100;
        }
        public void DoSomething()
        {
        }
    }
