    Public int Max
    {
        get { return m_Max; }
        set {
            if(value > 0 && value < 100){
                m_Max = value;
            }
        }
    }
