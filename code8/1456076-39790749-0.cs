    public class Person
    {
       [Key]
       public int Id { get; set; }
       public int Active { get; set; }
       [NotMapped]
       public bool IsActive 
       {
           get { return Convert.ToBoolean(Active); }
           set { Active = Convert.ToInt32(value); }
       }
    }
