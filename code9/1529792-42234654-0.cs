        class CPerson
        {
            private string m_sName;
            private string m_sPhone;
    
            public string Name
            {
                get { return this.m_sName; }
                set
                {
    
                    this.m_sName = value;
                }
            }
            public string Phone
            {
                get { return this.m_sPhone; }
                set
                {
                    this.m_sPhone = value;
                }
            }
    
            public override string ToString()
            {
                return Name + ": " + Phone;
            }
        }
    }
