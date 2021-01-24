    @{
        structState[] dumState = new structState[50];
    }
    @functions
    {
        struct structState
        {
            private string s_abbrev;
            public string abbrev
            {
                get
                {
                    return s_abbrev;
                }
                set
                {
                    s_abbrev = value;
                }
            }
            private string s_name;
            public string name
            {
                get
                {
                    return s_name;
                }
                set
                {
                    s_name = name;
                }
            }
            public structState(string a_abbrev, string a_name)
            {
                s_abbrev = a_abbrev;
                s_name = a_name;
            }
        }
    }
