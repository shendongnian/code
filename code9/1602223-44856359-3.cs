    public class ActivityFactory
    {
        public static List<Activity> GetActivities(object[][] values)
        {
            List<Activity> result = new List<Activity>();
            for (int i = 0; i < values.Length; i++)
            {
                result.Add(MakeActivity(values[i]));
            }
            return result;
        }
        static Activity MakeActivity(object[] values)
        {
            Activity result = null;
            switch (values[2].ToString())
            {
                case "Book":
                    result = new Book(values);
                    break;
                case "Journal":
                    result = new Journal(values);
                    break;
                case "Grant":
                    result = new Grant(values);
                    break;
                default:
                    throw new ArgumentException("Invalid activity " + values[2].ToString());
            }
            return result;
        }
        public static void RunTest()
        {
            object[][] values = new object[][] {
               new object[] { 2, 5, "Book", "13239382"},
               new object[] { 3, 5, "Journal", 5, 124},
               new object[] { 4, 5, "Journal", 8, 201},
               new object[] { 5, 5, "Journal", 8, 202},
               new object[] { 6, 5, "Grant", 444.00m}
           };
            List<Activity> activities = GetActivities(values);
        }
    }
