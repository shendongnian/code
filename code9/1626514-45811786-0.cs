    interface ISchoolRequirements
    {
         public string StudentTableName {get;}
         ... // other items that differ per school
    }
    class MySchoolRequirements : ISchooRequirements
    {
        ... // properties needed to create a StudentTableName
        // the function that composes the StudentTableName from the properties
        private string CreateStudentTableName() {...}
 
        // implementation of ISchoolRequirements
        public string StudentTableName {get{return this.CreateStudentTableName(); }
    }
    public class studentConfiguration : EntityTypeConfiguration<Models.student>
    {
        public studentConfiguration (ISchoolRequirement schoolRequirements)
        {
            this.ToTable(schoolRequirements.StudentTableName);
            ... // other configuration items
        }
    }
