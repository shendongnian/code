        public List<Student> GetOrderedStudents(List<Student> students)
        {
            Student[] reverseOrder = new Student[students.Count];
            
            Student last = students.Single(s => s.FollowedBy == null);
            reverseOrder[0] = last;
            Student next = last;
            
            for (var i = 1; i < students.Count; i++)
            {
                next = students.Single(s => s.FollowedBy == next.StudentID);
                reverseOrder[i] = next;
            }
            return reverseOrder.Reverse().ToList();  
        }
