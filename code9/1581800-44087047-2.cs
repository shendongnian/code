        public double CountPoints(Guid courseId)
        {
            var studentRepo = new StudentRepository();
            var student = studentRepo.FindById(this.Id);
            return 
                student.Evaluations
                .Where(e => e.Course.Id == courseId)
                .Sum(eval => eval.ObtainedPoints);
        }
