    public abstract class Brittle
    {
        private string _somethingWorthProtecting;
        public string SomethingWorthProtecting 
        {
            get { return _somethingWorthProtecting; }
            set
            {
                _somethingWorthProtecting = value;
                ReallyNeedToDoThisEverTimeTheValueChanges();
            }
        }
        //.....
    }
