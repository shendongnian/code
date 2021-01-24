     public class CADExpertInitalizeDB : DropCreateDatabaseIfModelChanges <CADExpertContext>
        {
            protected  override void Seed(CADExpertContext context)
            {
                context.CADExperts.Add(new CADExpert { Id = 1, Name = "Rice", inStock = true, Price = 30 });
                context.CADExperts.Add(new CADExpert { Id = 2, Name = "Sugar", inStock = false, Price = 40 });
                context.SaveChanges();
                base.Seed(context);
            }
        }
