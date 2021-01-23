            ArrayList studentsList = new ArrayList();
            studentsList.Add(s03);
            studentsList.Add(s04);
            studentsList.Add(s05);
            studentsList.Add(s01);
            studentsList.Add(s02);
            var studentsList2 = studentsList.Cast<Student>().OrderBy(r => r.surname).ToList();
            int i = 0;
            foreach (Student s in studentsList2)
            {
                i++;
                Console.Write("{0}. ", i);
                s.Describe();
            }
