    public class GenerateSection1 : GenerateXmlAbstract {
        public GenerateSection1(
                ResourceIntensiveObject1 student,
                ResourceIntensiveObject2 course,
                ResourceIntensiveObject3 user
        ) : base(student, course, user) { }
        
        public XmlElement Generate() {
            // some codes to return Xml
            return null;
        }
    }
