    public abstract class GenerateXmlAbstract {
        public ResourceIntensiveObject1 Student { get; private set; }
        public ResourceIntensiveObject2 Course { get; private set; }
        public ResourceIntensiveObject3 User { get; private set; }
        public GenerateXmlAbstract(
                ResourceIntensiveObject1 student,
                ResourceIntensiveObject2 course,
                ResourceIntensiveObject3 user
        ) {
            Student = student;
            Course = course;
            User = user;
        }
        public abstract XmlElement Generate();
    }
