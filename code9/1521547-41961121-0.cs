        public void TestSerialization()
        {
            var loops = 1000000;
            var w1 = new Stopwatch(); w1.Start();
            for (int i = 0; i < loops; i++)
            {
                var serializedDic = JsonConvert.SerializeObject(new Dictionary<string, string>() { { "Color", "Blue" }, { "Price", "5" } });
                var deserializedDic = JsonConvert.DeserializeObject(serializedDic);
            }
            w1.Stop();
            Debug.WriteLine(w1.Elapsed); //4.37 sec
            var w2 = new Stopwatch(); w2.Start();
            for (int i = 0; i < loops; i++)
            {
                var serializedObj = JsonConvert.SerializeObject(new CarObj() { Color = "blue", Price = 5 });
                var deserializedObj = JsonConvert.DeserializeObject(serializedObj);
            }
            w2.Stop();
            Debug.WriteLine(w2.Elapsed); //5.57 sec
        }
        public class CarObj
        {
            public string Color { get; set; }
            public float Price { get; set; }
        }
