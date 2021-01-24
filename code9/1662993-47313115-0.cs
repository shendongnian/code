    public class TestClass
    {
        [Test]
        public void TestMapper()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<GenericEntity, MyModel>()
                    .ForMember(d => d.ManagerId,
                               o => o.MapFrom(s => s.Properties.Single(n => n.Name == "ManagerId").Value));
            });
            var ge = new GenericEntity
            {
                Properties = new List<GenericProperty>
                {
                    new GenericProperty {Name = "ManagerId", Value = "Great"}
                }
            };
            var myModel = Mapper.Map<MyModel>(ge);
            Assert.AreEqual("Great", myModel.ManagerId);
        }
    }
