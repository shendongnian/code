    public static class StudentMapper
    {
        public static StudentDTO ToDTO(this Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                FacultyName = student.FacultyName.ToDTO()
            };
        }
        public static Student ToClass(this StudentDTO studentDTO)
        {
            return new Student
            {
                Id = studentDTO.Id,
                Name = studentDTO.Name,
                FacultyName = studentDTO.FacultyName.ToClass()
            };
        }
    }
