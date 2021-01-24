    class Trans
    {
        public List<string> name_list = new List<string>();
        public List<string> family_list = new List<string>();
        public List<string> phoneno_list = new List<string>();
        public List<string> name_Sec_list { set { name_list = value; } get { return name_list; } }
        public List<string> family_Sec_list { set { family_list = value; } get { return family_list; } }
        public List<string> phoneno_Sec_list { set { phoneno_list = value; } get { return phoneno_list; } }
    }
