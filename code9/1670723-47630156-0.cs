    public class HomeEditPostModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TownId { get; set; }
        [Required]
        public int StreetId { get; set; }
        [Required]
        public int HouseId { get; set; }
        [Required]
        public int FloorId { get; set; }
    }
