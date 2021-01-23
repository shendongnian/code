    public class MainClass
    {
        private CurrentClass _currentClass = new CurrentClass();
        public CurrentClass CurrentClass
        {
            get { return _currentClass; }
            set { _currentClass = value; }
        }
        public bool Initialized {get; private set;}
        public void Initialize()
        {
            this.CurrentClass.FirstCoefficient = 0;
            this.CurrentClass.SecondCoefficient = 5;
            this.Initialized = true;
        }
    }
