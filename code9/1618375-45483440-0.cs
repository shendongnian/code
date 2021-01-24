    class Context
    {
        MockTheLocation MockingObject;
        public Context()
        {
            MockingObject = new MockTheLocation(this); // 'this' is know in this scope
        }
    }
