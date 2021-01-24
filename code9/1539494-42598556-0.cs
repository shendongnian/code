    [TestClass]
    public class UnityTest
    {
        [TestMethod]
        public void MyTest()
        {
            var container = new UnityContainer();
    
            // Default registrations for IAnimal and ICage
            container.RegisterType<IAnimal, Cat>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICage, Cage>(new ContainerControlledLifetimeManager());
    
            container.RegisterType<ICage>(
                "cage2",
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new Cage(new Dog())));
    
            // Resolve ICage using the named registraion "cage2"
            var cage2 = container.Resolve<ICage>("cage2");
            Assert.AreEqual("Canis lupus", cage2.Animal.Species); // Assert succeeds
            // Resolve default
            var cage = container.Resolve<ICage>();
            Assert.AreEqual("Felis catus", cage.Animal.Species); // Assert succeeds
        }
    }
