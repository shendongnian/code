            public Student() : this(string.Empty, string.Empty)
            {
            }
    
            public Student(string fullname,string course) 
                : this (fullname,course, string.Empty, string.Empty, default(enumUniversity), default(enumSubject))
            {
            }
    
            public Student(string fullname, string course, string email, string phonenr, enumUniversity university, enumSubject subject)
            {
                this.fullName = fullname;
                this.course = course;
                this.email = email;
                this.phonenr = phonenr;
                this.university = university;
                this.subject = subject;
            }
