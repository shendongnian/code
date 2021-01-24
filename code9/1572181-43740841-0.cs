    public class Student
    {
        private DemoDatabaseEntities db = null;
        public Student(DemoDatabaseEntities dbContext){
        {
            this.db = dbContext;
        }
        public Student_Mast getStudentByID()
        {
            Student_Mast student = db.Student_Mast.Where(i => i.StudID == 1).FirstOrDefault();
            return student;
        }
    }
