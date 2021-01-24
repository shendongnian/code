      using (var db = new MyContext())
                {
                    db.Fields.Load();
                    db.Categories.Include(c => c.MainField).Include(x => x.Fields).Load();
                    db.FieldValues.Load();
                    return db.Objects.Include(x => x.MainFieldValue.Field).ToArray();
                } 
			
