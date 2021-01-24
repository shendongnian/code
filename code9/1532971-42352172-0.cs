      class BaseConstants
      {
        public int GetNumberOfPeople { get; set; } = 5;
      }
    
      class ProjectConstants:BaseConstants
      {
        public new int GetNumberOfPeople { get; set; } = 10;
      }
