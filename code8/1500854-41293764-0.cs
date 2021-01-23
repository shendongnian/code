    class Program
    {
        static void Main(string[] args)
        {
            String json = "{ 'A': 1, 'B' : 2, 'C' : 3 }";
            var classA = JsonConvert.DeserializeObject<MegaClass>(json,new AConverter());
            var classA2 = JsonConvert.DeserializeObject<MegaClass2>(json);
        }
        public class MegaClass2
        {
            public int A { get; set; }
            public SetOfVariables SetOfVariables1 { get; set; }
            public MegaClass2()
            {
                _additionalData = new Dictionary<string, JToken>();
                SetOfVariables1 = new SetOfVariables();
            }
            [JsonExtensionData]
            private IDictionary<string, JToken> _additionalData;
            [OnDeserialized]
            private void OnDeserialized(StreamingContext context)
            {
                int b = (int)_additionalData["B"];
                int c = (int)_additionalData["C"];
                SetOfVariables1.B = b;
                SetOfVariables1.C = c;
            }
        }
        public class MegaClass
        {
            public int A { get; set; }
            public SetOfVariables SetOfVariables1 { get; set; }
        }
        public class SetOfVariables
        {
            public int B { get; set; }
            public int C { get; set; }
        }
        public class AConverter : CustomCreationConverter<MegaClass>
        {
            public override MegaClass Create(Type objectType)
            {
                throw new NotImplementedException();
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                dynamic cl = serializer.Deserialize(reader);
                var classA = new MegaClass();
                classA.A = cl.A;
                var classB = new SetOfVariables();
                classB.B = cl.B;
                classB.C = cl.C;
                classA.SetOfVariables1 = classB;
                return classA;
            }
        }
    }
