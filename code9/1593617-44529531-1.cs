    public class Tests
    {
        [Fact]
        public void ShouldReturnJson()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new SomeDtoProfile()));
            var jObject = Mapper.Map<JObject>(new SomeDto {Name = "Bob"});
            Assert.Equal("{\r\n  \"Name\": \"Bob\"\r\n}", jObject.ToString());
        }
    }
