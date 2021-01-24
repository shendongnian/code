    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                                 
             }
        }
        public class cConnection
        {
            public cConnection Connection { get; set; }
            public List<cTable<Entity>> Table<Entiry>() { return null; } 
            public void Test()
            {
                int TestID = 123;
                var resultList = (from mainObjectEntity in Connection.Table<MainObjectEntity>().ToList()
                        join child1Entity in Connection.Table<Child1Entity>().ToList()
                        on mainObjectEntity.Id equals child1Entity.MainObjectEntityId
                        join child2Entity in Connection.Table<Child2Entity>().ToList()
                        on mainObjectEntity.Id equals child2Entity.MainObjectEntityId
                        where mainObjectEntity.TestId == TestID
                        select new
                        {
                            id = mainObjectEntity.TestId,
                            mainObjectEntity = mainObjectEntity,
                            child1 = child1Entity,
                            child2 = child2Entity
                        })
                        .GroupBy(x => x.id)
                        .Select(grp => new {
                            TestID = grp.FirstOrDefault().id,
                            Child1Entity = grp.Select(x => x.child1).ToList(),
                            Child2Entity = grp.Select(x => x.child2).ToList()
                         }).ToList();
            }
        }
        public class cTable<T> : Entity
        {
            public int MainObjectEntityId { get; set; }
            public int TestId { get; set; }
        }
        public class Entity
        {
            public int Id { get; set; }
        }
        public class Child1Entity : Entity
        {
           
        }
        public class Child2Entity : Entity
        {
        }
        public class MainObjectEntity : Entity
        {
        }
    }
