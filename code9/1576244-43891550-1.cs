    using YourProjectName.Models; //initialize your .cs file with this
    ...
    var options = new DbContextOptionsBuilder<ApplicationDbContext>();
    options.UseSqlServer(Configuration.GetConnectionStringSecureValue("DefaultConnection"));
    ApplicationDbContext context = new ApplicationDbContext(options); //somewhere else in the file
