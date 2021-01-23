            using (PersonDBEntities db = new PersonDBEntities())
            {
                try
                {
                    Departament dep = new Departament() { DepName = "New Department" };
                    db.Departament.Add(dep);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
