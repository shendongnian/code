using Bogus;
        // namespace, class, etc.
        // CategorySeeder seed method
        public int Seed(AppDbContext context)
        {
            var faker = new Faker<Category>()
                .RuleFor(r => r.IsGroup, () => true)
                .RuleFor(r => r.Parent, () => null)
                .RuleFor(r => r.UniversalTimeTicks, () => DateTime.Now.ToUniversalTime().Ticks)
                .RuleFor(r => r.Title, f => "Folder: " + f.Random.Word());
            var folders1 = faker.Generate(5);
            faker.RuleFor(r => r.Parent, () => folders1.OrderBy(r => Guid.NewGuid()).First());
            var folders2 = faker.Generate(10);
            var folders3 = folders1.Concat(folders2).ToArray();
            faker.RuleFor(r => r.Parent, () => folders3.OrderBy(r => Guid.NewGuid()).First());
            faker.RuleFor(r => r.Title, f => f.Random.Word());
            faker.RuleFor(r => r.IsGroup, () => false);
            var elements = faker.Generate(20);
            var allSeeds = elements.Concat(folders3).ToArray();
            context.AddRange(allSeeds);
            context.SaveChanges();
            return allSeeds.Length;
        }
        // ProductSeeder Seed method
        public int Seed(AppDbContext context)
        {
            var faker = new Faker<Product>()
                .RuleFor(r => r.Sku, f => f.Random.AlphaNumeric(8))
                .RuleFor(r => r.Title, f => f.Random.Word())
                .RuleFor(r => r.Category, () => context.Categories.Where(c => !c.IsGroup).OrderBy(o => Guid.NewGuid()).First());
            var prod = faker.Generate(50);
            context.AddRange(prod);
            context.SaveChanges();
            return prod.Count;
        }
Then create the service controller, that works only in development environment.
    public class DataGeneratorController : BaseController
    {
        public DataGeneratorController(IServiceProvider sp) : base(sp) { }
        public IActionResult SeedData()
        {
            var lst = new List<string>();
            if (!_dbContext.Categories.Any())
            {
                var count = new CategoryConfiguration().Seed(_dbContext);
                lst.Add($"{count} Categories have been seeded.");
            }
            if (!_dbContext.Products.Any())
            {
                var count = new ProductConfiguration().Seed(_dbContext);
                lst.Add($"{count} Products have been seeded.");
            }
            if (lst.Count == 0)
            {
                lst.Add("Nothing has been seeded.");
            }
            return Json(lst);
        }
    }
And call it from Insomnia\Postman whenever I want.
