    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Id, Name);
            }
        }
    }
