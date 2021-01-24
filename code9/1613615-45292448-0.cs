    [Table ("Reviews")]
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        public ReviewEnum Type { get; set; }
    
        public ICollection<MenuModel> Menus{ get; set; }
        public ICollection<StoreModel> Stpres{ get; set; }
}
