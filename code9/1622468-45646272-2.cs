    class ClassRoom
    {
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public ClassRoom()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }
        public static ClassRoom CreateDefault()
        {
            ClassRoom classRoom = new ClassRoom();
            classRoom.Students.Add(new Student("Henry", 20));
            classRoom.Students.Add(new Student("Jeff", 18));
            classRoom.Students.Add(new Student("Jessica", 22));
            classRoom.Teachers.Add(new Teacher("Lopez", "Math", 37));
            return classRoom;
        }
    }
