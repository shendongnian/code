    class Creature
    {
        // Here the = 100 part is the field initializer
        int _heathPoint = 100;
        // Each field can only have one initializer
        // So the line below is wrong and will not compile
        // _healthPoint = 30; // wrong because _heathPoint has been declared above
        public Creature()
        {
            // Do not need to do anything because the field initializer does what we want
        }
        public void DoSomething()
        {
        }
    }
