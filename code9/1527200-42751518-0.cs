    public class DocumentSale 
    {
       public List<DocumentSale> FollowDocuments {get; set;}
       public List<DocumentSale> BaseDocuments {get; set;}
    }
      modelBuilder.Entity<DocumentSale>()
            .HasMany<DocumentSale>(c => c.baseDocuments)
            .WithMany(c => c.followUpDocuments)
            .Map(
            cs =>
                {
                    cs.MapLeftKey("followdocid");
                    cs.MapRightKey("basedocid");
                    cs.ToTable("basefollow");
                }
            );
