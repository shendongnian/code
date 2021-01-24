    public class PollVM
    {
        public PollVM()
        {
            PollItems = new List<PollItemVM>();
        }
        public int id { get; set; }
      
        public string Title { get; set; }
        public virtual ICollection<PollItemVM> PollItems{ get; set; }
    }
    public class PollItemVM
    {
        public PollItemVM()
        {
            Choices = new List<ChoiceVM>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int? Reverse { get; set; }
        public virtual ICollection<ChoiceVM> Choices { get; set; }
    }
    public class ChoiceVM
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int Rate { get; set; }
    }
