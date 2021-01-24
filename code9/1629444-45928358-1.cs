    abstract class A
    {
        protected DrawingType m_type;
        protected virtual DrawingType Type
        {
            get { return m_type; }
            set { m_type = value; }
        }
    }
    class B : A
    {
        protected override DrawingType Type
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
