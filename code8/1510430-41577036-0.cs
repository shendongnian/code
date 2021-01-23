    class People
    {
        public string m_sName {get; set; }
        public string m_sEmail {get; set; }
        public People(){}
        public People(string name = null, string email = null)
        {
            m_sName = name;
            m_sEmail = email;
        }
