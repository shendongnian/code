        public interface ISpaceship { }
        public class Spaceship : ISpaceship { }
        public interface IRocket { }
        public class Rocket : IRocket { }
        [Fact]
        public void default_scanning_in_action()
        {
           var container = new Container(_ =>
           {
               _.Scan(x =>
               {
                x.Assembly("<AssemblyNameWhereClassesAreDefined>");
                x.WithDefaultConventions();
               });
           });
    
           var spacesfip = container.GetInstance<ISpaceship>().ShouldBeOfType<Spaceship>();
           var rocket = container.GetInstance<IRocket>().ShouldBeOfType<Rocket>();
        }
