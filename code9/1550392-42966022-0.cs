    namespace rdi_musica.infra
    {
       [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
       public class RdiContext : DbContext
       {
           public DbSet<Usuario> Usuarios { get; set; }
           public DbSet<Genero> Generos { get; set; }
           public DbSet<Banda> Bandas { get; set; }
           public DbSet<Musica> Musicas { get; set; }
    
       }
    }
