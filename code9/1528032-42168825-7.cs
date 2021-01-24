    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;
    
    namespace TestEF6.Data.Tests
    {
        [TestFixture]
        public class ProjectOrderTests
        {
            [Test]
            public void Can_Remove_Projects_And_Orders_Relation()
            {
                using (var db = new ProjectManagerContext())
                {
                    var proj1 = db.PROJECTs.Single(p => p.NAME == "TEST PROJ 1");
    
                    Debug.WriteLine($"Num of proj1 orders = [{proj1.ORDERS.Count}]");
                    foreach (var order in proj1.ORDERS.ToList())
                    {
                        Debug.WriteLine($"Removed proj order = [{proj1.NAME}] [{order.NAME}]");
                        proj1.ORDERS.Remove(order);
    
                    }
                    
                    db.SaveChanges();
                }
            }
            [Test]
            public void Can_Add_Projects_And_Orders()
            {
                using (var db = new ProjectManagerContext())
                {
                    var proj1 = new PROJECT { NAME = "TEST PROJ 1" };
                    var proj2 = new PROJECT { NAME = "TEST PROJ 2" };
                    var proj3 = new PROJECT { NAME = "TEST PROJ 3" };
                    db.PROJECTs.Add(proj1);
                    db.PROJECTs.Add(proj2);
                    db.PROJECTs.Add(proj3);
                    db.SaveChanges();
    
                    var order1 = new ORDER { NAME = "ORDER 1" };
                    var order2 = new ORDER { NAME = "ORDER 2" };
    
                    db.ORDERs.Add(order1);
                    db.ORDERs.Add(order2);
                    db.SaveChanges();
    
                    proj1.ORDERS.Add(order1);
                    proj1.ORDERS.Add(order2);
                    proj2.ORDERS.Add(order2);
    
                    db.SaveChanges();
                }
            }
    
            
        }
    }
