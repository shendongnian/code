    public class MyDBInitializer : CreateDatabaseIfNotExists<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            base.Seed(context);
        }
    }
