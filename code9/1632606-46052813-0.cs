    public class ClassA 
    {
        private int prop2;
        public int Prop2
        {
            get { return prop2; }
            set
            {
                prop2 = value;
                OnPropertyChange(nameof(Prop2));
            }
        }
        private int prop3;
        public int Prop3
        {
            get { return prop3; }
            set
            {
                prop3 = value;
                OnPropertyChange(nameof(Prop3));
            }
        }
    }
    public ClassB classB
    {
    	public ClassB(ClassA classAinstance)
    	{
    		classAinstance.PropertyChanged += (s,e) => OnPropertyChange(nameof(Prop1));
    	}
	
        public int Prop1
        {
            get { return (this.prop2 * 10 + this.Prop1 * 20 + classB.AnotherProperty*10); }
        }
    }
