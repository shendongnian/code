    public class MyPropertyClass
    {
        public MyPropertyClass(bool affectLogic)
        {
            _affectLogic = affectLogic;
        }
        private readonly bool _affectLogic;
        public string MyAutoProperty { get; set; }
        private string _myPropertyWithLogic;
        public string MyPropertyWithLogic
        {
            get
            {
                if (_affectLogic)
                    _myPropertyWithLogic = "Some value";
                return _myPropertyWithLogic;
            }
            set
            {
                if (_affectLogic)
                {
                    _myPropertyWithLogic = "Some value";
                }
                else
                {
                    _myPropertyWithLogic = value;
                }
                    
            }
        }
    }
