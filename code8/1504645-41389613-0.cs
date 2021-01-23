        public ApplicationContext(nameOrCxnString) : base(nameOrCxnString)
        {
        }
    
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<LigneCmd> LignesCmd { get; set; }
    }
