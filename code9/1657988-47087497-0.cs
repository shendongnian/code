    public class Parent
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalPrice
        {
            get
            {
                return Children == null ? 0 : Children.Sum(x => x.UnitePrice);
            }
        }
        //the rest of properties
        public virtual ICollection<Child> Children { get; set; }
    }
