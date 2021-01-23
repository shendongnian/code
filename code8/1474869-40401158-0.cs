    public Class Student : Entity 
    { 
       public string Firstname { get; set; }
       public virtual ICollection<Course> Courses { get; set; }
    }
    public Class Course : Entity 
    {
       public String Title { get; set; }
       public DateTime StartDate { get; set; }
       public virtual ICollection<Student> Students { get; set }
    }
