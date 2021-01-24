    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject4
    {
        [TestClass]
        public class UnitTest2
        {
            [TestMethod]
            public void TestMethod1()
            {
                var superHeroFactory = new SuperHeroFactory();
    
                var p1 = new Person {FullName = "Barry Allen", Abilities = {new Strong(), new WarpSpeed()}};
                p1.Hero = superHeroFactory.Create(p1);
    
                var p2 = new Person {FullName = "Mr F. Bar", Abilities = {new Crazy(), new Strong(), new CanFly()}};
                p2.Hero = superHeroFactory.Create(p2);
            }
        }
    
        public class SuperHeroFactory
        {
            private readonly List<Tuple<SuperHero, List<Ability>>> _profiles =
                new List<Tuple<SuperHero, List<Ability>>>
                {
                    new Tuple<SuperHero, List<Ability>>(
                        new SuperHero {Name = "The Flash"}, new List<Ability> {new WarpSpeed()}),
                    new Tuple<SuperHero, List<Ability>>(
                        new SuperHero {Name = "SuperFooB"}, new List<Ability> {new Crazy()}),
                    new Tuple<SuperHero, List<Ability>>(
                        new SuperHero {Name = "SuperFooB"}, new List<Ability> {new Strong(), new CanFly()})
                };
    
            public SuperHero Create(Person person)
            {
                // you may end up with more then one match here ))..
    
                return _profiles.FirstOrDefault(
                    profile => !person.Abilities.Except(profile.Item2).Any())?.Item1;
            }
        }
    
        public class Person
        {
            public string FullName { get; set; }
            public ICollection<Ability> Abilities { get; } = new List<Ability>();
            public SuperHero Hero { get; set; }
        }
    
        public class SuperHero
        {
            public string Name { get; set; }
        }
    
        public abstract class Ability { }
        public class Strong : Ability { }
        public class CanFly : Ability { }
        public class WarpSpeed : Ability { }
        public class Crazy : Ability { }
    }
