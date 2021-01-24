        public int GradeId { get; set; }
        public string GradeName { get; set; }
        
        public ICollection<Student> Students { get; set; }
        
        public Grade ()
        {
            Students = new Collection<Student>();
        }
    }
