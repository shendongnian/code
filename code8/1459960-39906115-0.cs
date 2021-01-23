    //Your entities
    public class Image
    {
        public Guid UserId { get; set; }
    
        public virtual User User { get; set; }
    }
    
    public class User
    {
        public Guid UserId { get; set; }
        
        public virtual Image Image { get; set; }
    }
    //Mappings:
    public class ImageMappingConfiguration : EntityTypeConfiguration<Image>
        {
            public ImageMappingConfiguration()
            {
                HasKey(x => x.UserId);
            }
        }
    
     public class UserMappingConfiguration : EntityTypeConfiguration<User>
        {
            public UserMappingConfiguration()
            {
                HasKey(x => x.UserId);
    
                HasOptional(x => x.Image)
                    .WithRequired(x => x.User);
            }
        }
