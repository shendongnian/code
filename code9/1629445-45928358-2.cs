    abstract class A
    {
        protected DrawingType m_type;
        public abstract DrawingType Type
        {
            get;
            set;
        }
    }
    class B : A
    {
        public override DrawingType Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = //custom logic goes here
            }
        }
    }
