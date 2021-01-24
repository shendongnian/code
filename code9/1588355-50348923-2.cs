    public class ServiceProviderCustomization : ICustomization {
    
            public void Customize(IFixture fixture) {
                var serviceProviderMock = fixture.Freeze<Mock<IServiceProvider>>();
    
                // GetService
                serviceProviderMock
                   .Setup(m => m.GetService(It.IsAny<Type>()))
                   .Returns((Type type) => {
                       var mockType = typeof(Mock<>).MakeGenericType(type);
                       var mock = fixture.Create(mockType, new SpecimenContext(fixture)) as Mock;
    
                       // Inject mock again, so the behavior can be changed with _fixture.Freeze()
                       MethodInfo method = typeof(FixtureRegistrar).GetMethod("Inject");
                       MethodInfo genericMethod = method.MakeGenericMethod(mockType);
                       genericMethod.Invoke(null, new object[] { fixture, mock });
    
                       return mock.Object;
                   });
    
                // Scoped
                var serviceScopeMock = fixture.Freeze<Mock<IServiceScope>>();
                serviceProviderMock
                   .As<IServiceScopeFactory>()
                   .Setup(m => m.CreateScope())
                   .Returns(serviceScopeMock.Object);
    
                serviceProviderMock.As<ISupportRequiredService>()
                    .Setup(m => m.GetRequiredService(typeof(IServiceScopeFactory)))
                    .Returns(serviceProviderMock.Object);
            }
        }
