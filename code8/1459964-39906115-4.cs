    public sealed class Image
    {
        public Image()
        {
            Users = new List<User>();
        }
    
        public Guid Id { get; set; }
    
        public Guid? UserId { get; set; }
    
        public List<User> Users { get; set; }
            
        public User User { get; set; }
    }
    
    public sealed class User
    {
        public User()
        {
            Images = new List<Image>();
        }
                
        public Guid Id { get; set; }
    
        public Guid? ImageId { get; set; }
    
        public List<Image> Images { get; set; }
    
        public Image Image { get; set; }
    }
    //Mappings:
    public class ImageMappingConfiguration : EntityTypeConfiguration<Image>
    {
        public ImageMappingConfiguration()
        {
            HasKey(x => x.Id);
    
            Property(x => x.UserId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_ImageMustBeUnique")
                {
                    IsUnique = true
                }));
    
    
            HasMany(x => x.Users)
                .WithOptional(x => x.Image)
                .HasForeignKey(x => x.ImageId)
                .WillCascadeOnDelete(true);
        }
    }
    
    public class UserMappingConfiguration : EntityTypeConfiguration<User>
    {
        public UserMappingConfiguration()
        {
            HasKey(x => x.Id);
    
            Property(x => x.ImageId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_UserMustBeUnique")
                {
                    IsUnique = true
                }));
    
            HasMany(x => x.Images)
                .WithOptional(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
