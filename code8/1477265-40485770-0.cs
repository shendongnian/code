    public MyClass : IMyClass, ISaveable, ILock
    {
        private readonly ISaveable _saveableImplementation;
        private readonly ILock _lockImplementation;
        
        public MyClass(ISaveable saveableImplementation, ILock lockImplementation)
        {
            _saveableImplementation = saveableImplementation;
            _lockImplementation - lockImplementation;
        }
        
        
        public void ISaveable.Save()
        {
            _saveableImplementation.Save();
        }
        
        public void ILock.Lock()
        {
            _lockImplementation.Lock();
        }
        
    }
