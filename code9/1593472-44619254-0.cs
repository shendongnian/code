    public SomeClass
    {
        public SomeClass(BedViewModelFactory bedViewModelFactory)
        {
            var bedViewModel = bedViewModelFactory(1.0, 2.0);
        }
    }
