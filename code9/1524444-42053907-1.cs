        public static string GetJsonString()
        {
            return "{ \"name\": \"ACCurrent\", " +
                   "  \"label\": \"ACCurrent\"," +
                   "  \"unit\": \"A\"," +
                   "  \"precision\": 2," +
                   "  \"type\": \"float\" }";
        }
    
        [Test]
        public void Deserialize_String_To_Some_Data()
        {
            var obj = JsonConvert.DeserializeObject<Data>(RawStringProvider.GetJsonString());
            Assert.AreEqual(typeof(float), obj.DataType);
        }
