     DBEntities db = new DBEntities();
      Animal a = new Animal();
      a.AnimalName = txtNew.Text;
      db.Animal.Add(a);
      db.SaveChanges();
      Debug.WriteLine(a.AnimalName);
