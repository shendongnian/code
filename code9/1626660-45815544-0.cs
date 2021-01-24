    public class GenericGoal
    {
        public int _id { get; set; }
        public List<String> Type_of_Goal { get; set; }
        public DateTime Date { get; set; }
    
        public GenericGoal()
        {
            Type_of_Goal = new List<String>();
        }
    }
