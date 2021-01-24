        [TestMethod]
        public void VerifyMappingsSecuritiesModule()
        {
            // Arrange
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Animal, AnimalDto>().ConvertUsing<TypeTypeConverter>();
                });
            var expectedAge = 10;
            var animal = new Animal { Age = expectedAge, AnimalType = EAnimalType.Cat };
            // Act
            var catDto = Mapper.Map<Animal, AnimalDto>(animal);
            // Assert
            Assert.IsInstanceOfType(catDto, typeof(CatDto));
            Assert.AreEqual(expectedAge, catDto.Age);
        }
        public class TypeTypeConverter : ITypeConverter<Animal, AnimalDto>
        {
            public AnimalDto Convert(ResolutionContext context)
            {
                var animal = (Animal)context.SourceValue;
                if (animal.AnimalType == EAnimalType.Cat) { return new CatDto { Age = animal.Age }; }
                else { return new DogDto { Age = animal.Age };  }
            }
        }
