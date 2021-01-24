     public class AddEditSupplierViewModel
     {
        [Key] // add key to Primary Key
        public int Id {get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
        public int SelectedRating { get; set; }
        public IEnumerable<SelectListItem> RatingList { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public double Commission { get; set; }
        public int PaymentTermId { get; set; }
        public IEnumerable<SelectListItem> PaymentTerms { get; set; }
        public bool Preferred { get; set; }
        public DateTime BEEExpiry { get; set; }
        public string SHEQ { get; set; }
        public AddEditSupplierViewModel()
        {
            var List = new List<int> { 1, 2, 3, 4, 5 };
            RatingList = List.Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });
        }
    }
