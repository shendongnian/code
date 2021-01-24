    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace WebApplication1.DAL
    {
        public class Student
        {
            DemoDatabaseEntities db;
            public Student(DemoDatabaseEntities _db)
            {
               this.db = _db
            }
            
            public Student_Mast getStudentByID()
            {
                Student_Mast student = db.Student_Mast
                                 .Where(i => i.StudID == 1).FirstOrDefault();
                return student;
            }
        }
    }
