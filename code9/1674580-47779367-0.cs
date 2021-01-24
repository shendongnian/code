            var student = sd.Students
                .Where(s => s.StudentID == id)
                .FirstOrDefault();
            if (student != null)
            {
                sd.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                sd.SaveChanges();
            }
