    public List<Student> ShowAllStudents()
    {
        var qstudent = from s in _db.Tbl_Students
                       join pr in _db.Tbl_Pye_Reshte on s.StudentID equals pr.StudentID
                       join r in _db.Tbl_Reshte on pr.ReshteID equals r.ReshteID
                       join p in _db.Tbl_Paye on pr.PayeID equals p.PayeID
                       orderby p.PayeID descending
                       select new Student { StudentName = s.StudentName, StudentFamily = s.StudentFamily, StudentImage = s.StudentImage, StudentPayeName = p.PayeName, StudentReshtName = r.ReshteName };
        return qstudent.ToList();
    }
