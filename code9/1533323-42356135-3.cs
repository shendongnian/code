            var students = new List<Student>
            {
                new Student {Name = "Test", Score = 10},
                new Student {Name = "Tom", Score = 5},
                new Student {Name = "Adam", Score = 90},
                new Student {Name = "Adam", Score = 85}
            };
            var orderedList = students.OrderByDescending(s => s.Score)
                .ThenBy(s => s.Name);
            foreach (var student in orderedList)
            {
                Debug.WriteLine($@"{student.Name} - {student.Score}");
            }
            /*  outputs:
                Adam - 90
                Adam - 85
                Test - 10
                Tom - 5
            */
