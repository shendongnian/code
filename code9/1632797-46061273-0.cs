    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    
    namespace ConsoleApp8
    {
        class Test
        {
            public int TestId { get; set; }
            public string Name { get; set; }
    
            public ICollection<Node> Nodes { get; } = new HashSet<Node>();
            public IEnumerable<LevelNode> LevelNodes
            {
                get
                {
                    return Nodes.OfType<LevelNode>(); 
                }
            }
    
            public IEnumerable<AttributeNode> AttributeNodes
            {
                get
                {
                    return Nodes.OfType<AttributeNode>();
                }
            }
      
    
        }
    
        abstract class Node
        {
            public int NodeId { get; set; }
    
            public string Key { get; set; }
    
            public string Value { get; set; }
    
            public virtual Node ParentNode { get; set; }
    
            public virtual ICollection<AttributeNode> Attributes { get; } = new HashSet<AttributeNode>();
    
            public Test Test { get; set; }
    
        }
    
        class LevelNode : Node
        {
            public virtual ICollection<LevelNode> Nodes { get; } = new HashSet<LevelNode>();
    
        }
    
        class AttributeNode : Node
        {
            public int Source { get; set; }
    
        }
        class TestCFContext : DbContext
        {
            public DbSet<Test> Tests { get; set; }
            public DbSet<LevelNode> LevelNodes { get; set; }
    
            public DbSet<AttributeNode> AttributeNodes { get; set; }
    
    
            public TestCFContext()
            {
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
    
    
    
        class Program
        {
            
    
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<TestCFContext>());
                // Test
                Test t = new Test() { Name = "My Test" };
    
                // Root & sub
                LevelNode root = new LevelNode() { Key = "root", Test = t };
                LevelNode sub = new LevelNode() { Key = "sub1", Test = t, ParentNode = root };
                root.Nodes.Add(sub);
                t.Nodes.Add(root);
    
                // Attr1
                AttributeNode attr1 = new AttributeNode() { Key = "Attr1 key", Value = "Attr1 value", Source = 1, Test = t, ParentNode = sub };
                AttributeNode subattr1 = new AttributeNode() { Key = "Subattr1 key", Value = "Subattr1 value", Source = 2, Test = t, ParentNode = attr1 };
                attr1.Attributes.Add(subattr1);
                sub.Attributes.Add(attr1);
    
                // Attr2
                sub.Attributes.Add(new AttributeNode() { Key = "Attr2 key", Value = "Attr2 value", Source = 3, Test = t, ParentNode = sub });
    
                // Add to DB
                using (TestCFContext c = new TestCFContext())
                {
                    c.Database.Log = m => Console.WriteLine(m);
                    c.Tests.Add(t);
                    c.SaveChanges();
    
                }
    
                using (TestCFContext c = new TestCFContext())
                {
                    c.Database.Log = m => Console.WriteLine(m);
                    // Perform search
                    IEnumerable<AttributeNode> resultAttributes = c.AttributeNodes.Where(x => x.Key == "Attr2 key" && x.Value == "Attr2 value");
                    var numFound = resultAttributes.Count();
                    Console.WriteLine($"{numFound} found.");
    
                }
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
    
    
            }
        }
    }
