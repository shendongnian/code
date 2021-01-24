    public abstract class ModelSource : ViewModelBase
    {
        abstract internal A accept<A>(IPropVisitor<A> visitor);
        abstract internal void accept<A>(IPropVisitor<A> visitor, A val);
    }
    class ModelA : ModelSource
    {
        private string myTextA;
        public string MyTextA
        {
            get { return myTextA; }
            set {
                myTextA = value;
                OnPropertyChanged("MyTextA");
            }
        }
        internal override A accept<A>(IPropVisitor<A> visitor)
        {
            return visitor.bindingMyText(this);
        }
        internal override void accept<A>(IPropVisitor<A> visitor, A val)
        {
            visitor.bindingMyText(this, val);
        }
        ViewModelVisitor sourceVisitor = new ViewModelVisitor();
    }
    class ModelB : ModelSource
    {
        private string myTextB;
        public string MyTextB
        {
            get { return myTextB; }
            set
            {
                myTextB = value;
                OnPropertyChanged("MyTextB");
            }
        }
        internal override A accept<A>(IPropVisitor<A> visitor)
        {
            return visitor.bindingMyText(this);
        }
        internal override void accept<A>(IPropVisitor<A> visitor, A val)
        {
            visitor.bindingMyText(this, val);
        }
    }
