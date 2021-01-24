     public class RoomNumber
     {
         public int Id { get; set; }
    
         [Required]
         public int RoomNumber { get; set; }
         [Required]
         public int BranchNameId { get; set; }
         public BranchName BranchName { get; set; } 
     }
