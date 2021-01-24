    class Program
    {
        static void Main(string[] args)
        {
            ObjectBasicFeatures[] ALLOBJECTS = new ObjectBasicFeatures[3];
            ALLOBJECTS[0] = new ObjectBasicFeatures("zero");
            ALLOBJECTS[1] = new ObjectBasicFeatures("one");
            ALLOBJECTS[2] = new ObjectBasicFeatures("two");
            ALLOBJECTS[1] = new ObjectBasicFeatures(ALLOBJECTS[0]);
            ALLOBJECTS[0].member = "Updated Value";
            ALLOBJECTS[0].level2Member.member = "Updated Level 2 Value";
            Console.WriteLine("At index 0 : " + ALLOBJECTS[0].member + ", Level2 : " + ALLOBJECTS[0].level2Member.member);
            Console.WriteLine("At index 1 : " + ALLOBJECTS[1].member + ", Level2 : " + ALLOBJECTS[1].level2Member.member);
            Console.ReadKey();
        }
    }
    public class ObjectBasicFeatures
    {
        public string member;
        public Level2 level2Member; // This is to demonstrate that it will be updated in both the objects
        public ObjectBasicFeatures(string memberVal)
        {
            member = memberVal;
            level2Member = new Level2("Level 2 Value");
        }
        /// Constructor to copy member values.
        public ObjectBasicFeatures(ObjectBasicFeatures originalObject)
        {
            member = originalObject.member;
            level2Member = originalObject.level2Member;
        }
    }
    /// This class does not have a constructor to copy member values.
    public class Level2 
    {
        public string member;
        public Level2(string memberVal)
        {
            member = memberVal;
        }
    }
