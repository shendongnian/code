        public class Student
        {
            public int StudentId
            {
                get;
                set;
            } = 1;
            public string StudentName
            {
                get;
                set;
            } = "Name";
        }
        public class Teacher
        {
            public int TeacherId
            {
                get;
                set;
            } = 666;
            public string TeacherName
            {
                get;
                set;
            } = "TeacherName";
        }
        public class StudentTeacher
        {
            public Student Student
            {
                get;
            } = new Student();
            public Teacher Teacher
            {
                get;
            } = new Teacher();
        }
        public static dynamic GetAnonType(Student student, Teacher teacher)
        {
            var propertyNamesAndPropertiesStudent = student.GetType().GetProperties().Select(item => Tuple.Create($"{nameof(Student)}{item.Name}", item.GetMethod.Invoke(student, null)));
            var propertyNamesAndPropertiesTeacher = teacher.GetType().GetProperties().Select(item => Tuple.Create($"{nameof(Teacher)}{item.Name}", item.GetMethod.Invoke(teacher, null)));
            dynamic sampleObject = new ExpandoObject();
            foreach(var propertyNamePropertyValuePair in propertyNamesAndPropertiesStudent)
            {
                ((IDictionary<string, object>)sampleObject).Add(propertyNamePropertyValuePair.Item1, propertyNamePropertyValuePair.Item2);
            }
            foreach(var propertyNamePropertyValuePair in propertyNamesAndPropertiesTeacher)
            {
                ((IDictionary<string, object>)sampleObject).Add(propertyNamePropertyValuePair.Item1, propertyNamePropertyValuePair.Item2);
            }
            return sampleObject;
        }
