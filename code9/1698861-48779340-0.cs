    public class UserBills
    {
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
    }
