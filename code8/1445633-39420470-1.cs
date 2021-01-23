    public static class MyConvenientFactory
    {
        public static MyService CreateDefaultMyService()
        {
            return new MyService(new ObjectA(), new ObjectB());
        }
    }
