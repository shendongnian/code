    public class Account
        {
            public virtual ICollection<Submission> Submissions { get; set; }
        }
    public class Submission
    {
        public virtual Account Account { get; set; }
    }
