        public class SourceEntity
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        public class TargetEntity
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        public void Sample()
        {
            SourceEntity sourceEntity = new SourceEntity { Name = "Test name", StartDate = DateTime.Now.AddDays(-3) };
            TargetEntity targetEntity = JObject.FromObject(sourceEntity).ToObject<TargetEntity>();
        }
