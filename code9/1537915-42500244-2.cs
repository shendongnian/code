    Public int Max
        {
            get { return m_Max; }
            set {
                if(value > 0 && value < 100){ \\Value is within valid range
                    m_Max = value;
                }
                else if(value < 0)
                    //throw some exception to indicate value is not valid
                else if(value > 0)
                    //throw some exception to indicate value is not valid 
            }
        }
