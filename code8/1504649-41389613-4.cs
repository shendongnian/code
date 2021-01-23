    public abstract class ApplicationContext : DbContext
    {
        public ApplicationContext(string nameOrCxnString) : base("name=" + nameOrCxnString)
        {
        }
    
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<LigneCmd> LignesCmd { get; set; }
    }
