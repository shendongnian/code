    public class ClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }
        public Client Client { get; set; }
        // FK, use [ForeignKey( "Client" )] if you wish
        public int ClientId { get; set; }
    }
    // or use FluentAPI
    modelBuilder.Entity<ClientScope>()
        .HasRequired( cs => cs.Client )
        .WithMany( c => c.Scopes )
        // specify foreign key
        .HasForeignKey( cs => cs.ClientId );
    // now can specify a client by setting the ClientId property
    var scope = new ClientScope() 
    { 
        ClientId = 1, 
        Id = 1, 
        Scope = "Test Scope",
    }
    UpdateClientScope(scope);
