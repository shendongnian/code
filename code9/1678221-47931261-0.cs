    public int Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var student = db.Students.Find(id);
                var curso = from t in db.Teachers
                            join i in db.Inscriptions on id equals i.StudentId
                            where t.Id == i.StudentId
                            select i.Id;
                var atten = from a in db.Attendances
                            where a.InscriptionId == curso.FirstOrDefault() //this line was modified
            }
        }
