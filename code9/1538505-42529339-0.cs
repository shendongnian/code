    [Table("__EFMigrationsHistory")]
    public class MigrationHistory
    {
        [Key]
        [MaxLength(150)]
        public string MigrationId { get; set; }
        [MaxLength(32)]
        public string ProductVersion { get; set; }
    }
