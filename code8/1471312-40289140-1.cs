    		[TestMethod]
		public void TestMethod3()
		{
			var schemaType = typeof(ExampleSchema);
			var dtoType = typeof(ExampleDto);
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap(schemaType, dtoType)
					.ForMember("Weight", conf => conf.Ignore());
			});
            config.AssertConfigurationIsValid();
			var mapper = config.CreateMapper();
			var schema = new ExampleSchema { Age = 10 };
			var dto = mapper.Map<ExampleDto>(schema);
			Assert.AreEqual(dto.Age, 10);
			Assert.AreEqual(dto.Weight, 0);
		}
