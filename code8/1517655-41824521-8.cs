      [Test]
        public void Test_Mapping_Profile_Must_Detect_Unmapped_Properties()
        {
            var config = new MapperConfiguration(cfg =>
            {
                    cfg.AddProfile<TestMappingProfile>();
            });
            ar mapper = config.CreateMapper();
    
            var unmappedProperties = GetUnmappedSimpleProperties();
            Assert.AreEqual(unmappedProperties.Count, 12);
        }
    
        public class TestMappingProfile : Profile
        {
            public TestMappingProfile()
            {
                CreateMap<Source, DestinationValid>();
                CreateMap<Source, DestinationInvalid>();
            }
        } 
    
    
        internal class Source
        {
            public string Test1 { get; set; }
            public int Test2 { get; set; }
            public int? Test3 { get; set; }
            public decimal Test4 { get; set; }
            public string[] Test5 { get; set; }
    
            public Guid Test6 { get; set; }
            public Guid? Test7 { get; set; }
            public TransactionRealm Test8 { get; set; }
    
            public bool? Test9 { get; set; }
            public bool Test10 { get; set; }
    
            public DateTime Test11 { get; set; }
            public DateTime? Test12 { get; set; }
        }
    
        internal class DestinationValid
        {
            public string Test1 { get; set; }
            public int Test2 { get; set; }
            public int? Test3 { get; set; }
            public decimal Test4 { get; set; }
            public string[] Test5 { get; set; }
    
            public Guid Test6 { get; set; }
            public Guid? Test7 { get; set; }
            public TransactionRealm Test8 { get; set; }
    
            public bool? Test9 { get; set; }
            public bool Test10 { get; set; }
    
            public DateTime Test11 { get; set; }
            public DateTime? Test12 { get; set; }
        }
    
        internal class DestinationInvalid
        {
            public string Test1X { get; set; }
            public int Test2X { get; set; }
            public int? Test3X { get; set; }
            public decimal Test4X { get; set; }
            public string[] Test5X { get; set; }
            public Guid Test6X { get; set; }
            public Guid? Test7X { get; set; }
            public TransactionRealm Test8X { get; set; }
            public bool? Test9X { get; set; }
            public bool Test10X { get; set; }
    
            public DateTime Test11X { get; set; }
            public DateTime? Test12X { get; set; }
        }
