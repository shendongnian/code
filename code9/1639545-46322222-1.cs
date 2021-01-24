    public class MyReadInitializer : DropCreateDatabaseIfModelChanges<MyReadContext>
            {
                protected override void Seed(MyReadContext context)
                {
                    context.products.Add(
                      new Product { description = "Product1" }
                    );
                    context.SaveChanges()
                    base.Seed(context);
                }
        }
