    abstract class A
    {
        protected DrawingType m_type;
        protected abstract DrawingType Type
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
                m_type = new DrawingType(); //custom logic
            }
        }
    }
