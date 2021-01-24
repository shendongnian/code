    [Table("Stores")]
    public class StoreModel
    {
    
        [Key]
        public int Id { get; set; }
    
        [Required]
        [MaxLength(25)]
        public string StoreName { get; set; }
    
        [MaxLength(80)]
        public string StoreShortDescription { get; set; }
    
        [MaxLength(4000)]
        public string StoreFullDescription { get; set; }
    
        public string StoreLocation { get; set; }
        public string StoreAddress { get; set; }
        public int StoreMainPhotoId {get;set;}
    
    
        #region graphics Data
        [ForeignKey(nameof(StoreMainPhotoId))]
        public StorePhotoModel StoreMainPhoto { get; set; }
        public ICollection<StorePhotoModel> StorePhotos { get; set; }
        #endregion
    
        public ICollection<MenuModel> Menus { get; set; }
        public ICollection<StoreReviewModel> StoreReviews { get; set; }
    
        #region store contacts
        public string StorePhoneNumber { get; set; }
        public string StoreExtraContacts { get; set; }
        #endregion
    
        public StoreModel()
        {
            StorePhotos = new Collection<StorePhotoModel>();
            Menus = new Collection<MenuModel>();
            StoreReviews = new Collection<StoreReviewModel>();
        }
    }
