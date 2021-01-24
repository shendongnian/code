    class Assignment
    {
         public int Id {get; set;}
         
         // every assignment has exactly one AssignmentSettingInfo
         // use aggregation (in entity framework terms: complextype)
         public AssignmentSettingInfo AssignmentSettingInfo {get; set;}
    }
    [ComplexType]
    class AssignmentSettingInfo
    {
        // Every AssignmentSettingInfo has zero or one Lesson
        public virtual Lesson Lesson { get; set; }
    }
