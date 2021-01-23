    public class CourseInstructor : AuditableEntity
    {        
       #region Primitive Properties
       [Required(ErrorMessage = "CourseID is required.")]
       [ForeignKey("Course")]
       public int CourseID { get; set; }
    
       [Required(ErrorMessage = "StudentID is required.")]
       [ForeignKey("Student")]
       public int PersonID { get; set; }
       #endregion
    
       #region Navigation Properties
    
       public virtual Course Course { get; set; }
       public virtual Person Student { get; set; }
       #endregion 
    }
