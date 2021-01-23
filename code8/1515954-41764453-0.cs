    Hi this is the  way you can achive what you want to do . I just added a line on OnMidelCreating and then testted the code woith 
   
      var result = context.MaineMenu.ToList(); // here I gold child menus in the list 
     
    public class NavigationMenuContext : DbContext
    {
    public NavigationMenuContext() : base("name=DefaultConnection")  
    {
    }
    public DbSet<NavigationMenu> NavigationMenus { get; set; }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
        -- this is changed -- 
        modelBuilder.Entity<NavigationMenu>().HasMany(c => c.MenuChildren);
     }
    }
