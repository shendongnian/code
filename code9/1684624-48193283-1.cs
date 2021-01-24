    public class BranchName
     {
         public int Id { get; set; }
    
         [Required]
         public string Name { get; set; }
    
         public List<RoomNumber> RoomNumbers { get; set; } 
     }
