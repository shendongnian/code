    public class MyServiceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
               new TypeRelay(
                  typeof(IService),
                  typeof(MyService)));
        }
    }
