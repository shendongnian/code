      class Program
        {
            static void Main(string[] args)
            {
    
                Ninject.IKernel kernel = new StandardKernel(new TestModule());
    
                var samurai = kernel.Get<Samurai>();
                samurai.Attack("your enemy");
    
                Console.ReadLine();
            }
        }
    
    
        public interface IWeapon
        {
            string Hit(string target);
        }
    
        public class Sword : IWeapon
        {
            public string Hit(string target)
            {
                return "Slice " + target + " in half";
            }
        }
    
        public class Dagger : IWeapon
        {
            public string Hit(string target)
            {
                return "Stab " + target + " to death";
            }
        }
    
        public class Samurai
        {
            readonly IWeapon[] allWeapons;
    
            public Samurai(IWeapon[] allWeapons)
            {
                this.allWeapons = allWeapons;
            }
    
            public void Attack(string target)
            {
                foreach (IWeapon weapon in this.allWeapons)
                    Console.WriteLine(weapon.Hit(target));
            }
        }
    
        class TestModule : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                Bind<IWeapon>().To<Sword>();
                Bind<IWeapon>().To<Dagger>();
            }
        }
