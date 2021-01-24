            List<Students> students = new List<Students>()
            {
                new Students() {Name = "Ray", Year = "2017"},
                new Students() { Name = "Carla", Year = "2019" }
            };
            List<Teachers> teachers = new List<Teachers>()
            {
                new Teachers() {Name = "Mr. Smith", TeacherId = 151},
                new Teachers() {Name = "Mrs. Barbara", TeacherId = 901}
            };
            listBox1.Items.AddRange(teachers.Select(x => x.Name).ToArray());
            listBox1.Items.AddRange(students.Select(s => s.Name).ToArray());
