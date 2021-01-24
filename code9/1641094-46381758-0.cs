        public class Rootobject
    {
        public int time { get; set; }
        public Dictionary<string, ChildObject> pairs { get; set; }
    }
    public class ChildObject
    {
        public int books { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public float fee { get; set; }
    }
    class Program
    {
        static string json = @"
            {""time"":1506174868,""pairs"":{
            ""AAA"":{""books"":8,""min"":0.1,""max"":1.0,""fee"":0.01},
            ""AAX"":{""books"":8,""min"":0.1,""max"":1.0,""fee"":0.01},
            ""AQA"":{""books"":8,""min"":0.1,""max"":1.0,""fee"":0.01}
            }
        }";
        static void Main(string[] args)
        {
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(json);
            foreach(var child in root.pairs)
            {
                Console.WriteLine(string.Format("Key: {0}, books:{1},min:{2},max:{3},fee:{4}", 
                    child.Key, child.Value.books, child.Value.max, child.Value.min, child.Value.fee));
            }
        }
