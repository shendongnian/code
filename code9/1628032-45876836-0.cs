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
        public static IEnumerable<object> EnumerateProperties(object instance) 
        {
            var testClass = instance.GetType();
            var properties = testClass.GetProperties();
            var propertyGetAccessor = properties.Select(property => property.GetMethod);
            return propertyGetAccessor.Select(getMethod => getMethod.Invoke(instance, null));
        }
