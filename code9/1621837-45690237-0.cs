        [TestMethod]
        public void TestMethod1()
        {
            var source = new Source();
            source.SourceList.Add("IntValue", (int) 3);
            source.SourceList.Add("DoubleValue", (double) 3.14);
            Mapper.Initialize(config =>
            {
                //"Magic code"
                config.CreateMap<Source, IDestination>();
                config.CreateMap(typeof(Source), typeof(Destination)).IncludeBase(typeof(Source), typeof(IDestination));
            });
            //standard map-call
            var destination = Mapper.Map<Destination>(source);
            //Additional "Trick":
            Dictionary<string, object> mappingDict =
                source.SourceList.ToDictionary(pair => pair.Key, pair => (object) pair.Value);
            Mapper.Map(mappingDict, destination, typeof(Dictionary<string, object>), typeof(Destination));
            Assert.AreEqual(source.Name, destination.Name);
            Assert.AreEqual(source.SourceList["IntValue"], destination.IntValue);
            Assert.AreEqual(source.SourceList["DoubleValue"], destination.DoubleValue);
        }
