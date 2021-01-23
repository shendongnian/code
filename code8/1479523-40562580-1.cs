    [MetadataType(typeof(AddressMetadata))]
    public partial class Address
    {
    }
    public class AddressMetadata
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, 
        ErrorMessage="The max. length of the street name is 100 characters.")]
        public string Street { get; set; }
        public Nullable<short> Street_Number { get; set; }
        [Required]
        public Nullable<decimal> Zip { get; set; }
        [Required]
        [RegularExpression(@"[a-z,A-Z]",ErrorMessage="Only characters are allowed.")]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
