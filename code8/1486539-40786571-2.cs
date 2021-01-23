    class PersonInfo
    {
        public string StackOverFlowName { get; set; }
        public string Experience { get; set; }
        public GuruLevel GuruStatus { get; set; }
        public void PersonInfo(Person p)
        {
          StackOverFlowName = p.StackOverFlowName;
          Experience = p.Experience;
          GuruStatus = p.Experience > 9000 ? GuruLevel.SuperSayan : GuruLevel.Goku;
        }
    }
