    protected override void Seed(BookService.Models.BookServiceContext context)
    {
        context.Users.AddOrUpdate(x => x.Id,
        new ApplicationUser () { Id = 1, FirstName = "FirstName", LastName="LastName", PasswordHash="<hash from dbase>" }
        );       
    }
